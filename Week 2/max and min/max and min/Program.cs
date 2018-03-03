using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace max_and_min
{
    class Program
    {
        static void Main(string[] args)
        {

            string line = File.ReadAllText(@"C:\Users\Askar\Desktop\input.txt");
                string[] s = line.Split();
                int max = int.Parse(s[0]);
                int min = int.Parse(s[0]);
                for (int i = 0; i < s.Length; i++)
                {
                    if (int.Parse(s[i]) > max)
                    {
                        max = int.Parse(s[i]);
                    }

                    if (int.Parse(s[i]) < min)
                    {
                        min = int.Parse(s[i]);
                    }
                }
                Console.WriteLine(min);
                Console.WriteLine(max);
                Console.ReadKey();
            }
        }
    }
