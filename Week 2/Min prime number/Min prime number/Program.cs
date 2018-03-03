using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Min_prime_number
{
    class Program
    {
        static bool f(int a)
        {
            for(int i=2; i<=Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            string x = File.ReadAllText(@"C:\Users\Askar\Desktop\input.txt");
            string[] line = x.Split();
            int min = int.Parse(line[0]);
            for(int i=0; i<line.Length; i++)
            {
                if (f(int.Parse(line[i]) ))
                {
                    if (int.Parse(line[i]) < min)
                    {
                        min = int.Parse(line[i]);
                    }
                }
            }
            File.WriteAllText(@"C:\Users\Askar\Desktop\output.txt",Convert.ToString(min));
        }
    }
}
