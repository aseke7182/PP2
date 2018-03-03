using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        int step = 0;
        public List<Point> body = new List<Point>();
        public Snake()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(5, 5);
            body.Add(new Point(5, 5));//initial point
            Console.WriteLine('o');
        }
        public void Move(int dx, int dy)
        {
            body[0].x += dx;//move right/left
            body[0].y += dy;//move updown
        }
        public bool CollisionWithFood(Food food)//snake's collision with food
        {
            if(body[0].x== food.food.x && body[0].y == food.food.y)
            {
                body.Add(new Point(0, 0));
                return true;
            }
            return false;
        }
        public bool CollisionWithBody()//snake's collision with his body
        {
            for(int i=2; i < body.Count; i++)
            {
                if(body[0].x == body[i].x && body[0].y == body[i].y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CollisionWithWall(Wall wall)//snake's collision with wall
        {
            foreach(Point p in wall.wall)
            {
                if(body[0].x == p.x && body[0].y == p.y)
                {
                    return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            step++;
            if ( step == 1)
            {
                body.Add(new Point(0, 0));//to make new  body
                Console.SetCursorPosition(5, 5);
                Console.Write(' ');
            }
                Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);//set cursor to the last body's coordinate
                Console.Write(' ');//to donot clear all text
            for (int i = body.Count-1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;//to move our snake gradually
            }
            int cnt = 0;
            foreach(Point i in body)
            {
               
                if (i.x > Console.WindowLeft + 60)
                {
                    i.x = 1;
                }
                if (i.x < 1)
                {
                    i.x = Console.WindowLeft + 60;
                }
                if (i.y < 1)
                {
                    i.y = Console.WindowTop + 18;
                }
                if (i.y > Console.WindowTop + 18)
                {
                    i.y = 1;//if snake leaved playing area 
                }
                Console.SetCursorPosition(i.x, i.y);
                if(body.Count<2)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("o");//HEAD 
                if (cnt == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;//HEAD
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;//BODY
                }
                cnt++;
            }
        }
    }
}