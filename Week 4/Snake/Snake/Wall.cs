using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Wall
    {
        public List<Point> wall = new List<Point>();//for easy use walls
        public Wall(int level)
        {
            StreamReader sr = new StreamReader("level "+level + ".txt");//wall path
            Console.ForegroundColor = ConsoleColor.Yellow;
            int x= int.Parse(sr.ReadLine());//number of y
            for( int i= 0; i<x; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == '*')
                    {
                        wall.Add(new Point(j,i));//add wall into vector
                    }
                }
            }
            Draw();
            sr.Close();
        }
        public void Draw()
        {
            for(int i=0; i < wall.Count; i++)
            {
                Console.SetCursorPosition(wall[i].x, wall[i].y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (wall[i].x == 0 || wall[i].y == 0 || wall[i].y == 19 || wall[i].x == 61)//where snake could not pass
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                Console.Write('*');   //make wall visible
            }
        }
    }
}
