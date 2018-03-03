using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    [Serializable]
    public class Snake
    {
        public List<Point> body = new List<Point>();
        public static int cnt = 1;
        public Snake()
        {
        }
        public void Head() => body.Add(new Point(5, 5));
        public void Ser()
        {
            if (File.Exists("snake.xml"))
            {
                File.Delete("snake.xml");
            }
            FileStream fs = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(Snake));
            xml.Serialize(fs, this);
            fs.Close();
        }
        public Snake Des()
        {
            FileStream fs1 = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xml1 = new XmlSerializer(typeof(Snake));
            Snake snake = xml1.Deserialize(fs1) as Snake;
            fs1.Close();
            return snake;
        }
        public void Move(int dx, int dy)
        {

            if (body.Count < 2)
            {
                Console.SetCursorPosition(body[0].x, body[0].y);
                Console.Write(" ");
            }
            body[0].x += dx;//move right/left
            body[0].y += dy;//move updown
           
        }
        public bool CollisionWithFood(Food food)//snake's collision with food
        {
            if(body[0].x== food.food.x && body[0].y == food.food.y)
            {
                if (cnt == 1)
                {
                    body.Add(new Point(1, 18));
                    cnt = 0;
                    Console.SetCursorPosition(food.food.x, food.food.y);
                    Console.Write(" ");
                }
                body.Add(new Point(1,18));
                Console.SetCursorPosition(1,18);
                Console.Write(" ");
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
           
            Console.SetCursorPosition(body[body.Count-1].x,body[body.Count-1].y);//set cursor to the last body's coordinate
            Console.Write(' ');//to donot clear all text
            for (int i = body.Count-1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;//to move our snake 
            }
            int cnt = 0;
            foreach(Point i in body)
            {
               
                if (i.x > Console.WindowLeft + 59)
                {
                    i.x = 1;
                }
                if (i.x < 1)
                {
                    i.x = Console.WindowLeft + 59;
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
                //HEAD 
                if (cnt == 1 || body.Count==1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;//HEAD
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;//BODY
                }
                Console.Write("o");
                cnt++;
            }
        }
    }
}