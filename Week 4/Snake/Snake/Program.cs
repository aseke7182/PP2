using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int last = 0;//if right , then no left
            int level = 1;
            int success = 0;//to do not refresh
            Console.SetCursorPosition(35, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome To Snake Game");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("Reach 110 score to complete level and complete 10 levels to finish game");
            Console.SetCursorPosition(25, 9);
            Console.WriteLine("Please, Enter Your Name");
            Console.SetCursorPosition(30, 10);
            string line = Console.ReadLine();//user's name
            Console.CursorVisible = false;
            Console.Clear();
            Wall wall = new Wall(level);
            Snake snake = new Snake();
            Score s = new Score();
            Food food = new Food(wall, snake);
            Console.ForegroundColor = ConsoleColor.Green;
            while (true) {
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow && last != 2)
                {
                    snake.Move(0, 1);
                    last = 1;
                    success = 1;
                }
                if (key.Key == ConsoleKey.UpArrow && last != 1)
                {

                    snake.Move(0, -1);
                    last = 2;
                    success = 1;
                }
                if (key.Key == ConsoleKey.LeftArrow && last != 4)
                {
                    snake.Move(-1, 0);
                    last = 3;
                    success = 1;
                }
                if (key.Key == ConsoleKey.RightArrow && last != 3)
                {
                    snake.Move(1,0);
                    last = 4;
                    success = 1;
                }//head's move
                if (success == 1)
                {
                    snake.Draw();
                    wall.Draw();
                }
                success = 0;
                if (snake.CollisionWithFood(food))
                {
                    score = score + 10; // every food = 10 point
                    if (score >= 110)
                    {
                        level++;
                        if (level > 10)
                        {
                            Console.SetCursorPosition(30, 5);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Congratulations!!!");
                            Console.SetCursorPosition(30, 6);
                            Console.WriteLine("You completed My Game");
                            Console.ReadKey();
                            return;
                        }
                        score = 0;
                        last = 0; 
                        Console.Clear();
                        wall = new Wall(level);
                        snake = new Snake();
                        food = new Food(wall,snake);
                        s.Draw(score, level);// if level up
                    }
                    food = new Food(wall,snake);
                    s.Draw(score,level);// score , level, and food point refresh
                }
                if (snake.CollisionWithBody() || snake.CollisionWithWall(wall))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    Console.SetCursorPosition(30, 7);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(28, 8);
                    Console.WriteLine("Your score is " + ((level - 1) * 110 + score));
                    Console.SetCursorPosition(27, 9);
                    Console.WriteLine("press R to restrart or Q to quit");
                    /*...............................................................................................................
                    string maxscore = "0";
                    FileStream fs = new FileStream(line + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    XmlSerializer xml = new XmlSerializer(typeof(string));
                    maxscore = xml.Deserialize(fs) as string;
                    if (score > int.Parse(maxscore))
                    {
                        try
                        {
                            xml.Serialize(fs, score.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        finally
                        {
                            fs.Close();
                        }
                    }
                    */

                  /*  int maxscore = 0;
                    if (File.Exists(line + ".txt"))
                    {
                        StreamReader sr = new StreamReader(line+".txt");
                        maxscore = int.Parse(sr.ReadToEnd());
                        sr.Close();
                    }
                    else
                    {
                        File.Create(line + ".txt");
                        File.WriteAllText(line + ".txt", "0");
                    }
                    if (score > maxscore)
                    {
                        File.WriteAllText(line + ".txt", score.ToString());
                    }*/


                    //....................................................................................................
                    score = 0;
                    level = 1;//if Game Over
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleKeyInfo kki = Console.ReadKey();
                        if (kki.Key == ConsoleKey.R)
                        {
                            break;
                        }
                        if(kki.Key == ConsoleKey.Q)
                        {
                            return ;
                        }//Quit or Restart
                    }
                    Console.Clear();
                    wall = new Wall(level);
                    snake = new Snake();
                    food = new Food(wall,snake);
                    s.Draw(score,level);//start game from the beginning
                }
            }
        }
    }
}
