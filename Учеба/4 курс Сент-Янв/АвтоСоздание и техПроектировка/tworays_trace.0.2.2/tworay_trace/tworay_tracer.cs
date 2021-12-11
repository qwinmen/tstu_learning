using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class walker
    {
        public Point pos;
        public Point main_ray;
        public Point asist_ray;
        public int counter;
        public int side;

        bool is_assist;

        public walker(Point p, Point m, Point a,int s)
        {
            pos = p;
            main_ray = m;
            asist_ray = a;
            side = s;
            counter = 0;
            is_assist = false;

        }

        public void change_ray()
        {
            Point t = main_ray;
            main_ray = asist_ray;
            asist_ray = t;
            is_assist = !is_assist;
        }

        public bool is_can_go(Feald<int> feald)
        {
            Point next = pos.plus(main_ray);
            if (
                (next.X >= feald.Width)||
                (next.Y>= feald.Height)||
                (next.X <0) ||
                (next.Y<0)
                )return false;

            return feald.at[next.X][next.Y] > (counter+1) ;
        }

        public int next_value(Feald<int> feald)
        {
            Point next = pos.plus(main_ray);
            if (
          (next.X >= feald.Width) ||
          (next.Y >= feald.Height) ||
          (next.X < 0) ||
          (next.Y < 0)
          ) return feald.area;
            return feald.at[next.X][next.Y];
        }

        public Point next()
        {
            return pos.plus(main_ray);           
        }

        public void go(Feald<int> feald,Feald<int> cookies)
        {
            ++counter;
            pos= pos.plus(main_ray);
            feald.at[pos.X][pos.Y] = counter;
            cookies.at[pos.X][pos.Y] = side;
            if (is_assist) change_ray();
        }
    }

    class tworay_tracer
    {
        Feald<int> data;
        Feald<int> cookies;

        bool conected;
        Point col1, col2;
        Point[] rays;

        List<walker> walkers;
        List<Point> way;
        public tworay_tracer()
        {
        }

        public List<Point> trace(Feald<int> orgn,line task)
        {
            way= new List<Point>();
            data = new Feald<int>(orgn);
            cookies = new Feald<int>(orgn);
            cookies.Fill(0);

            data.at[task.begin.X][task.begin.Y] = 0;
            data.at[task.end.X][task.end.Y] = 0;

            cookies.at[task.begin.X][task.begin.Y] = 1;
            cookies.at[task.end.X][task.end.Y] = -1;

            walkers= new List<walker>(4);

            rays = new Point[4];

            rays[0]=task.end.minus(task.begin).bymax_norm();
            rays[1] = task.end.minus(task.begin).bymin_norm();
            if (rays[1] == new Point(0, 0)) rays[1] = rays[0].rot_to_left();

            rays[2] = rays[0].reverse();
            rays[3] = rays[1].reverse();

            conected = false;
            int id;

            for (int i = 0; i < 9; ++i)
            {
                walkers.Clear();
                walkers.Add(new walker(task.begin, i == 5 ? rays[0].reverse() : rays[0],
                                                    i == 1 ? rays[1].reverse() : rays[1], 1));
                walkers.Add(new walker(task.begin, i == 6 ? rays[1].reverse() : rays[1],
                                                   i == 2 ? rays[0].reverse() : rays[0], 1));
                walkers.Add(new walker(task.end, i == 7 ? rays[2].reverse() : rays[2],
                                                 i == 3 ? rays[3].reverse() : rays[3], -1));
                walkers.Add(new walker(task.end, i == 8 ? rays[3].reverse() : rays[3],
                                                 i == 4 ? rays[2].reverse() : rays[2], -1));


                while ((!conected) && (walkers.Count() > 0))
                {
                    for (id = 0; id < walkers.Count(); ++id)
                    {
                        go(id);
                    }
                }
                if (conected) break;
            }
           if(conected) find_way(task.begin, task.end);

            return way;
        }

        void find_way(Point begin, Point end)
        {
            List<Point> half_way1= new List<Point>(),
                 half_way2 = new List<Point>(); 

            Point cur=col1;


            while ((cur != begin) && (cur != end))
            {
                half_way1.Add(cur);
                cur=next_waypoint(cur);
            }
            half_way1.Add(cur);
            data.at[col1.X][col1.Y] = data.area;

            cur = col2;
            while ((cur != begin) && (cur != end))
            {
                half_way2.Add(cur);
                cur = next_waypoint(cur);
            }
            half_way2.Add(cur);
            half_way1.Reverse();
            way.AddRange(half_way1);
            way.AddRange(half_way2);

        }

        Point next_waypoint(Point p)
        {
            int min;

            min = data.area;
            Point minima=p;

            foreach (Point ray in rays)
            {
                Point neo = p.plus(ray);
                if (data.is_inside(neo.X, neo.Y))
                {
                    if((data.at[neo.X][neo.Y] < min)&&(data.at[neo.X][neo.Y] >=0))
                    {
                        if (cookies.at[neo.X][neo.Y] == cookies.at[p.X][p.Y])
                        {
                            min = data.at[neo.X][neo.Y];
                            minima = neo;
                        }
                    }
                }
            }
            return minima;
        }


        void go(int id)
        {
            if (!walkers[id].is_can_go(data))
            {
                if ((walkers[id].next_value(data) >=0 )&&(walkers[id].next_value(data)!=data.area))
                {
                    Point next= walkers[id].next();

                    if (cookies.at[next.X][next.Y] != walkers[id].side)
                    {
                        conected = true;
                        col1 = walkers[id].pos;
                        col2 = walkers[id].pos.plus(walkers[id].main_ray);

                        return;
                    }
                }

                walkers[id].change_ray();
                if (!walkers[id].is_can_go(data))
                {
                    if ((walkers[id].next_value(data) >= 0) && (walkers[id].next_value(data) != data.area))
                    {
                        Point next = walkers[id].next();

                        if (cookies.at[next.X][next.Y] != walkers[id].side)
                        {
                            conected = true;
                            col1 = walkers[id].pos;
                            col2 = walkers[id].pos.plus(walkers[id].main_ray);

                            return;
                        }
                    }
                    walkers.RemoveAt(id);
                    return;
                }
            }

            walkers[id].go(data,cookies);
         //   way.Add(walkers[id].pos);
        }


       
       
    }
}
