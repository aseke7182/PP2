using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Shop
{
    class Program
    {
        public static int cursor = 0, cursor1 = 0, sum = 0,cursor3=0;
        public static DirectoryInfo di = new DirectoryInfo(@" C:\Users\Askar\Desktop\PP2\Shop\OnlineShop");
        public static FileInfo[] dd = di.GetFiles();
        public static Shop shop = new Shop();
        public static List<Product> list = new List<Product>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello There. Please, Enter Your Cash, That You Have");
            long x =long.Parse(Console.ReadLine());
            Console.Clear();
            Console.CursorVisible = false;
            while (true)
            {
                for(int i=0; i < dd.Length; i++)
                {
                    string b = "";
                    string a = dd[i].ToString();
                    for(int j =0; j < a.Length; j++)
                    {
                        if (a[j] == '.') { break; }
                        b += a[j];
                    }
                    if(cursor == i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(b);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("If you wonna exit from our shop press 'D'");
                Console.WriteLine("Your Cash:" + (x-sum));
                ConsoleKeyInfo kki = Console.ReadKey();
                if(kki.Key == ConsoleKey.DownArrow)
                {
                    cursor += 1;
                    if (cursor > dd.Length - 1)
                    {
                        cursor = 0;
                    }
                }
                if(kki.Key == ConsoleKey.UpArrow)
                {
                    cursor -= 1;
                    if (cursor < 0)
                    {
                        cursor = dd.Length - 1;
                    }
                }
                if(kki.Key == ConsoleKey.D)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Items You Bought:");
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (i == cursor3) { Console.ForegroundColor = ConsoleColor.DarkRed; }
                            else { Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine(list[i]);
                        }
                        if (kki.Key == ConsoleKey.DownArrow)
                        {
                            cursor3 += 1;
                            if (cursor3 > list.Count - 1)
                            {
                                cursor3 = 0;
                            }
                        }
                        if (kki.Key == ConsoleKey.UpArrow)
                        {
                            cursor3 -= 1;
                            if (cursor3 < 0)
                            {
                                cursor3 = list.Count - 1;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Money Spend: " + sum);
                        Console.WriteLine("Money left: " + (x - sum));
                        Console.WriteLine();
                        Console.WriteLine("Press F to Close Window");
                        Console.WriteLine("Press C to buy something more");
                        Console.WriteLine("Press Q to delete this object from this list");
                        kki = Console.ReadKey();
                        if (kki.Key == ConsoleKey.F)
                        {
                            Console.Clear();
                            Console.WriteLine("Thanks for coming, Come to our shop more");
                            Console.ReadKey();
                            return;
                        }
                        if (kki.Key == ConsoleKey.C)
                        {
                            break;
                        }
                        if(kki.Key == ConsoleKey.Q)
                        {
                            sum -= list[cursor3].n;
                            list.Remove(list[cursor3]);
                        }
                    }
                }
                if (kki.Key == ConsoleKey.Enter)
                {
                    while (true)
                    {
                        StreamReader sr = new StreamReader(dd[cursor].FullName);
                        string s =sr.ReadToEnd();
                        string[] ss = s.Split('\n');
                        if (kki.Key == ConsoleKey.DownArrow)
                        {
                            cursor1 += 1;
                        }
                        if (kki.Key == ConsoleKey.UpArrow)
                        {
                            cursor1 -= 1;
                        }
                        if (cursor1 == ss.Length)
                        {
                            cursor1 = 0;
                        }
                        if (cursor1 < 0)
                        {
                            cursor1 = ss.Length - 1;
                        }
                        Console.Clear();
                        for (int i = 0; i < ss.Length; i++)
                        {
                            if (cursor1 == i)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(ss[i]);
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Please Press 'B' to mark this item or 'escape' to escape from this section");
                        Console.WriteLine("Your Cash:" + (x-sum));
                        Console.WriteLine("If you wonna exit from our shop press 'D'");
                        kki = Console.ReadKey();
                        if (kki.Key == ConsoleKey.B)
                        {
                            string[] a = ss[cursor1].Split();
                            int cost = int.Parse(a[1]);
                            string name = a[0].ToString();
                            Console.Clear();
                            if (cost <= x)
                            {
                                Console.WriteLine("You successfully marked this item");
                                list.Add(new Product(name, cost));
                                Console.ReadKey();
                                sum += cost;
                            }
                            else
                            { 
                                Console.WriteLine("Sorry, You have not enough money");
                                Console.WriteLine("Please try to buy something another");
                                Console.ReadKey();
                            }cursor1 = 0;
                        }
                        if (kki.Key == ConsoleKey.D)
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Items You Bought:");
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (i == cursor3) { Console.ForegroundColor = ConsoleColor.DarkRed; }
                                    else { Console.ForegroundColor = ConsoleColor.White; }
                                    Console.WriteLine(list[i]);
                                }
                                if (kki.Key == ConsoleKey.DownArrow)
                                {
                                    cursor3 += 1;
                                    if (cursor3 > list.Count - 1)
                                    {
                                        cursor3 = 0;
                                    }
                                }
                                if (kki.Key == ConsoleKey.UpArrow)
                                {
                                    cursor3 -= 1;
                                    if (cursor3 < 0)
                                    {
                                        cursor3 = list.Count - 1;
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.WriteLine("Money Spend: " + sum);
                                Console.WriteLine("Money left: " + (x - sum));
                                Console.WriteLine();
                                Console.WriteLine("Press F to Close Window");
                                Console.WriteLine("Press C to buy something more");
                                Console.WriteLine("Press Q to delete this object from this list");
                                kki = Console.ReadKey();
                                if (kki.Key == ConsoleKey.F)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Thanks for coming, Come to our shop more");
                                    Console.ReadKey();
                                    return;
                                }
                                if (kki.Key == ConsoleKey.C)
                                {
                                    break;
                                }
                                if (kki.Key == ConsoleKey.Q)
                                {
                                    sum -= list[cursor3].n;
                                    list.Remove(list[cursor3]);
                                }
                            }
                        }
                        if (kki.Key == ConsoleKey.Escape)
                        {
                            cursor1 = 0;
                            break;
                        }
                    }cursor = 0;
                }
                Console.Clear();
            }
        }
    }
}
