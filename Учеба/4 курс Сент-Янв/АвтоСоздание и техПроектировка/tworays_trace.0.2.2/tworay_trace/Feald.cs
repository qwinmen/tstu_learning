using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace System
{
    
    
    public class Feald<T>
    {
        
        T[][] mass;
        int width;
        int height;


        public Feald()
        {
            this.width = 0;
            this.height = 0;

            mass =null;
        }


        public Feald(int width,int height)
        {
            this.width = width;
            this.height = height;

            mass=alloc(this.width,this.height);
            Fill(default(T));
        }

        public Feald(Feald<T> orig)
        {            
            this.width = orig.width;
            this.height = orig.height;

            mass = alloc(this.width, this.height);

            for (int x = 0; x < this.width; ++x)
            {
                for (int y = 0; y < this.height; ++y)
                {
                    this.mass[x][y] = orig.mass[x][y];
                }
            }
        }

        T[][] alloc(int width, int height)
        {
           T[][] new_mass= new T[width][];
            for( int i =0; i<width ;++i)
            {
                new_mass[i]= new T[height];
            }
            return new_mass;
        }

        public bool Empty()
        {
            return (this.width * this.height) != 0;
        }

        public void Fill(T value)
        {
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    mass[x][y] = value;
                }
            }
        }

        public void Fill(T value, Rectangle rect)
        {
            for (int x = rect.X; x < rect.X+rect.Width; ++x)
            {
                for (int y = rect.Y; y < rect.Y+rect.Height; ++y)
                {
                    mass[x][y] = value;
                }
            }
        }

        public void Fill(T value, int X, int Y , int Width, int Height)
        {
            for (int x = X; x < X + Width; ++x)
            {
                for (int y = Y; y < Y + Height; ++y)
                {
                    mass[x][y] = value;
                }
            }
        }

        public  T  get(int x, int y)
        {
            return  mass[x][y];
        }

        public void set(int x, int y,T val)
        {
            mass[x][y]=val;
        }


        public void Resize(int width,int height)
        {
            this.height = height;
            this.width = width;

            if (width * height != 0)
            {

                T[][] new_mass = alloc(width, height);
                clone(mass, new_mass);
                mass = new_mass;

            }
            else
            {
                mass = null;
            }
        }

        void clone(T[][] original, T[][] clone)
        {
            for (int x = 0; (x < original.Length)&&(x<clone.Length); ++x)
            {
                for (int y = 0;(y < original[x].Length)&&(y<clone[x].Length); ++y)
                {
                     clone[x][y]= original[x][y];
                }
            }
        }

        public int area
        {get{return width*height;}}

        public int Width
        {
            get
            {
                return this.width;
            }
        }
         
        public int Height
        {
            get
            {
                return this.height;
            }
        }

        public T[][] at
        {
            get
            {
                return mass;
            }
        }       

        public bool is_inside(int x,int y){
            if (!(x < (width)) || (x < 0) ||
                !(y < (height)) || (y < 0)) return false;
            return true;
        }
    }

}
