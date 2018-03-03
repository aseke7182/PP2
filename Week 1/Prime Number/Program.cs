using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();//make string
            string[] arr = line.Split(' ');// разделить между прробелами
            for (int i = 0; i < arr.Length; i++)
            {
                int n = int.Parse(arr[i]);// convert in integer
                bool asd =  true;// make boolean
                if (n == 1)// функция ниже не работает для 1
                {
                    continue;
                }
                for (int j = 2; j <= Math.Sqrt(n); j++)
                {
                    if (n % j == 0)
                    {
                        asd = false;// check it on prime number
                        break;
                    }
                }
                if (asd == true) {
                    Console.WriteLine(n);// make cout
                }
            }
            Console.ReadKey();
        }
    }
}
