using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_Manager
{
    class Program
    {
        static int console_size = 20; 
        static void ShowInfo(DirectoryInfo df, int cursor, int size)
        {
            int index = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] ss = df.GetFileSystemInfos();
            for(int i=0; i < ss.Length; i++)
            {
                FileSystemInfo fsi = ss[i];
                if (fsi.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if(fsi.GetType()== typeof(FileInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if(cursor == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (index >= size && index <= size + console_size)
                {
                    Console.WriteLine(fsi.Name);
                }
                index++;
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo df = new DirectoryInfo(@"C:\Users\Askar\Desktop\KBTU");
            int cursor = 0;
            int size = 0;
            ShowInfo(df,cursor,size);
            while (true)
            {
                ConsoleKeyInfo kki=Console.ReadKey();
                FileSystemInfo[] a = df.GetFileSystemInfos();
                int n = a.Length;
                if(kki.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                    {
                        cursor = n - 1;
                        size = cursor - console_size;
                    }
                    if (cursor < size)
                    {
                        size--;
                    }
                }
                if(kki.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                    {
                        cursor = 0;
                        size = 0;
                    }
                    if (cursor > size+console_size)
                    {
                        size++;
                    }
                }
                if(kki.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if(kki.Key == ConsoleKey.Enter)
                {
                    if(a[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        df = new DirectoryInfo(a[cursor].FullName);
                        cursor = 0;
                        size = 0;
                        n = a.Length;
                    }
                    else if (a[cursor].GetType() == typeof(FileInfo))
                    {
                        StreamReader sr = new StreamReader(a[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(s);
                        while (true)
                        {
                            ConsoleKeyInfo qwe = Console.ReadKey();
                            if (qwe.Key == ConsoleKey.Q)
                            {
                                ShowInfo(df, cursor, size);
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine(s);
                        }
                    }
                }
                if(kki.Key == ConsoleKey.B)
                {
                    if (df.Parent != null ){
                        df = df.Parent;
                        cursor = 0;
                        size = 0;
                        n = a.Length;
                    }
                    else
                    {
                        break;
                    }
                }
                ShowInfo(df,cursor,size);
            }
        }
    }
}
