using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace Snake
{
    class Program
    {
        public static int last = 0;//if right , then no left
        public static void F()
        {
            while (true)
            {
                if (last == 1)
                {
                    snake.Move(0, 1);
                }
                if (last == 2)
                {
                    snake.Move(0, -1);
                }
                if (last == 3)
                {
                    snake.Move(-1, 0);
                }
                if(last == 4)
                {
                    snake.Move(1, 0);
                }
                snake.Draw();

                if (snake.CollisionWithFood(food))
                {
                    speed = speed - 20;
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
                        speed = 300;
                        score = 0;
                        last = 0;
                        Console.Clear();
                        wall = new Wall(level);
                        snake = new Snake();
                        snake.Head();
                        food = new Food(wall, snake);
                        snake.Draw();
                        s.Draw(score, level);// if level up
                    }
                    food = new Food(wall, snake);
                    food.Draw();
                    s.Draw(score, level);// score , level, and food point refresh
                }
                if (snake.CollisionWithBody() || snake.CollisionWithWall(wall))
                {
                    string ss = "";
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    Console.SetCursorPosition(30, 7);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(28, 8);
                    Console.WriteLine("Your score is " + ((level - 1) * 110 + score));
                    Console.SetCursorPosition(27, 9);
                    Console.WriteLine("press R to restrart or Q to quit");
                    Console.SetCursorPosition(28, 10);
                    Console.WriteLine("Your Best score is " + ss);
                    score = 0;
                    level = 1;//if Game Over
                    speed = 300;
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleKeyInfo kki = Console.ReadKey();
                        if (kki.Key == ConsoleKey.R)
                        {
                           break;
                        }
                        if (kki.Key == ConsoleKey.Q)
                        {
                            return;
                        }//Quit or Restart
                    }
                    wall = new Wall(level);
                    snake = new Snake();
                    snake.Head();
                    food = new Food(wall, snake);
                    Console.Clear();
                    s.Draw(score, level);//start game from the beginning
                    snake.Draw();
                    wall.Draw();
                    food.Draw();
                }
                Thread.Sleep(speed);
            }
        }
        public static int speed = 300;
        public static int score = 0;
        public static int success = 0;//to do not refresh
        public static int level = 1;
        public static Wall wall = new Wall(level);
        public static Snake snake = new Snake();
        public static Score s = new Score(score, level);
        public static Food food = new Food(wall, snake);
        static void Main(string[] args)
        {
            Console.Clear();
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
            snake.Head();
            snake.Draw();
            food.Draw();
            wall.Draw();
            s.Draw(score,level);
           Thread thread = new Thread(F);
            thread.Start();
            while (true) {
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow && last != 2 && last !=1)
                {
                    snake.Move(0, 1);
                    last = 1;
                    success = 1;
                }
                if (key.Key == ConsoleKey.UpArrow && last != 1 && last!=2)
                {

                    snake.Move(0, -1);
                    last = 2;
                    success = 1;
                }
                if (key.Key == ConsoleKey.LeftArrow && last != 4 && last !=3)
                {
                    snake.Move(-1, 0);
                    last = 3;
                    success = 1;
                }
                if (key.Key == ConsoleKey.RightArrow && last != 3 &&  last != 4)
                {
                    snake.Move(1,0);
                    last = 4;
                    success = 1;
                }//head's move
                if(key.Key== ConsoleKey.F2)
                {
                    snake.Ser();
                    food.Ser();
                    s.Ser(score);
                    s.Ser1(level);
                    wall.Ser();
                }
                if(key.Key == ConsoleKey.F3)
                {
                    snake = snake.Des();
                    wall = wall.Des();
                    score = int.Parse(s.Des());
                    level = int.Parse(s.Des1());
                    food = food.Des();
                    Console.Clear();
                    food.Draw();
                    wall.Draw();
                    s.Draw(score, level);
                    success = 1;
                    Console.ReadKey();
                }
                if (success == 1)
                {
                    snake.Draw();
                    food.Draw();
                    if (snake.body.Count < 2)
                    {
                        wall.Draw();
                    }
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
                        speed = 300;
                        score = 0;
                        last = 0; 
                        Console.Clear();
                        wall = new Wall(level);
                        snake = new Snake();
                        snake.Head();
                        food = new Food(wall,snake);
                        snake.Draw();
                        s.Draw(score, level);// if level up
                    }
                    food = new Food(wall, snake);
                    food.Draw();
                    s.Draw(score,level);// score , level, and food point refresh
                }
                if (snake.CollisionWithBody() || snake.CollisionWithWall(wall))
                {
                    thread.Abort();
                    string ss = "";
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    Console.SetCursorPosition(30, 7);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(28, 8);
                    Console.WriteLine("Your score is " + ((level - 1) * 110 + score));
                    Console.SetCursorPosition(27, 9);
                    Console.WriteLine("press R to restrart or Q to quit");
                    int maxscore = 0;
                    if (!File.Exists(line + ".txt"))
                    {
                        File.WriteAllText(line + ".txt","0");
                    }
                    ss= File.ReadAllText(line + ".txt");
                    Console.SetCursorPosition(28, 10);
                    Console.WriteLine("Your Best score is " + ss);
                    maxscore = int.Parse(ss);
                    if (maxscore < score)
                    {
                        File.WriteAllText(line + ".txt",score.ToString());
                    }//Highscore
                    score = 0;
                    level = 1;//if Game Over
                    speed = 300;
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleKeyInfo kki = Console.ReadKey();
                        if (kki.Key == ConsoleKey.R)
                        {
                            thread = new Thread(F);
                            thread.Start();
                            break;
                        }
                        if(kki.Key == ConsoleKey.Q)
                        {
                            return ;
                        }//Quit or Restart
                    }
                    wall = new Wall(level);
                    snake = new Snake();
                    snake.Head();
                    food = new Food(wall,snake);
                    Console.Clear();
                    s.Draw(score,level);//start game from the beginning
                    snake.Draw();
                    wall.Draw();
                    food.Draw();
                }
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
}
