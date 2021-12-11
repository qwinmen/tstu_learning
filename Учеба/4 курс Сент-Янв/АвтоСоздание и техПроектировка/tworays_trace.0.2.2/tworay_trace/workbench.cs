using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{

    public class line
    {
        public Point begin, end;
        public Color color;
        public int id;

  

        public line(Point begin_in, Point end_in, int id_in)
        {
            begin = begin_in;
            end = end_in;
            id = id_in;
            color = Color.Gold;
        }
    }



    public class workbench
    {
        Feald<int> data;
      public  List<line> lines;
        public List<List<Point>> ways;
      public int inter_space  ;

      public List<Point> chips;


        public int width { get { return data.Width; } }
        public int height { get { return data.Height; } }

        public workbench(int width, int height)
        {
            inter_space = 1;
            ways = new List<List<Point>>();
            lines = new List<line>();

             chips = new List<Point>();
            data = new Feald<int>(width, height);
            data.Fill(data.area);
        }


        public void clean()
        {  ways = new List<List<Point>>();
            lines = new List<line>();
            data = new Feald<int>(width, height);
            chips = new List<Point>();
            data.Fill(data.area);
        }

        public int get(int x, int y)
        {
            return data.at[x][y];
        }

        public void set(int x, int y, int value)
        {
            data.at[x][y] = value;
        }

        public void add_chip(Point begin, Point end,int val=-1,bool add_to_list=true)
        {
            add_chip(begin.X, begin.Y, end.X, end.Y,val,add_to_list);
        }

        public void add_chip(int begin_x, int begin_y, int end_x, int end_y,int val=-1,bool add_to_list=true)
        {
            
            int t = 0;
            if (begin_x > end_x)
            {
                t = begin_x;
                begin_x = end_x;
                end_x = t;
            }

            if (begin_y > end_y)
            {
                t = begin_y;
                begin_y = end_y;
                end_y = t;
            }

            if (add_to_list) chips.Add(new Point(begin_x + end_x, begin_y + end_y).mult(0.5f));
            
            for (int x = begin_x; x < end_x; ++x)
            {
                for (int y = begin_y; y < end_y; ++y)
                {
                    set_data(x, y, val);
                  //  data.at[x][y] =-1;
                }
            }
        }


        public void add_line(int begin_x, int begin_y, int end_x, int end_y)
        {
            add_line(new Point(begin_x, begin_y), new Point(end_x, end_y));
        }

        public void add_line(Point begin, Point end)
        {
            lines.Add(new line(begin, end, lines.Count + 2));
         //   data.at[begin.X][begin.Y] =- 1;
         //   data.at[end.X][end.Y] = - 1;
        }


         void drop_way(List<Point> way){

            if (way.Count == 0) return;

            Point dir,begin=way[0];

            foreach (Point end in way)
            {
                dir = end.minus(begin).bymax_norm();
                while (begin != end)
                {
                    add_chip(begin.minus(new Point(inter_space,inter_space)),begin.plus(new Point(inter_space+1,inter_space+1)),-2,false);
                    begin = begin.plus(dir);
                }

            }

        }

         void set_data(int x, int y, int value)
         {
             if (data.is_inside(x, y)&&(data.at[x][y]>0)) data.at[x][y] = value;

             
         }
        public bool trace()
        {
            try
            {
                ways.Clear();
                foreach (line l in lines)
                {
                    tworay_tracer tracer = new tworay_tracer();
                    ways.Add(tracer.trace(data,l));
                    drop_way(ways[ways.Count - 1]);
                }
            }
            catch (System.StackOverflowException e)
            {

            }
            return true;
        }




    }
}
