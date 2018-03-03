using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp4
{
    class Program
    {
        public static void F()
        {
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(1000);
                Console.Clear();
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(1000);
                Console.Clear();
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(F);
            while (true)
            {
                for(int i = 0; i < 4; i++)
                {
                    for(int j=0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                Console.Clear();
                thread.Start();
                Console.ReadKey();
            }
        }
    }
}
