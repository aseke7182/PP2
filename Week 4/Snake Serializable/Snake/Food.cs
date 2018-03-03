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
     public class Food
    {
        public Point food;
        public Food() { }
        public void Ser()
        {
            if (File.Exists("food.xml"))
            {
                File.Delete("food.xml");
            }
            FileStream fs = new FileStream("food.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(Food));
            xml.Serialize(fs, this);
            fs.Close();
        }
        public Food Des()
        {
            FileStream fs1 = new FileStream("food.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xml1 = new XmlSerializer(typeof(Food));
            Food food = xml1.Deserialize(fs1) as Food;
            fs1.Close();
            return food;
        }
        public Food(Wall wall, Snake snake)
        {
            Random randomx = new Random();
            Random randomy = new Random();
            int y = randomy.Next(1, 19);
            int x = randomx.Next(1, 61);//random integer
            bool access = true;
            while (access)//Is food on snake or wall?
            {
                access = false;
                x = randomx.Next(1, 60);
                y = randomy.Next(1, 19);
                foreach (Point p in wall.wall)
                {
                    if (p.x == x && p.y == y)
                    {
                        access = true;
                    }
                }
                for (int i = 0; i < snake.body.Count; i++)
                {
                    if (snake.body[i].x == x && snake.body[i].y == y)
                    {
                        access = true;
                    }
                }
            }
          //  ....................................................................................
            food = new Point(x, y);// give coordinate for our food
            Draw();
        }
        public void Draw()
        {
            Console.SetCursorPosition(food.x, food.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$");//draw our food
        }
    }
}
