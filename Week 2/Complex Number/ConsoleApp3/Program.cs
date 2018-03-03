using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Complex
    {
        public int up;
        public int down;
        public Complex(int a, int b)
        {
            up = a;
            down = b;
        }
        public static int gcd(int a, int b)
        {
            if (Math.Min(a, b) != 0)
            {
                return gcd(Math.Min(a, b), Math.Max(a, b) % Math.Min(a, b));
            }
            else
            {
                return Math.Max(a, b);
            }
        }
        public void Simplify()
        {
            int al = gcd(up, down);
            down /= al ;
            up /= al;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c = new Complex(c1.down / gcd(c1.down, c2.down) * c2.down / c1.down * c1.up + c1.down / gcd(c1.down, c2.down) * c2.down / c2.down * c2.up, c1.down / gcd(c1.down, c2.down) * c2.down);
            c.Simplify();
            return c;
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex c = new Complex(c1.down / gcd(c1.down, c2.down) * c2.down / c1.down * c1.up - c1.down / gcd(c1.down, c2.down) * c2.down / c2.down * c2.up, c1.down / gcd(c1.down, c2.down) * c2.down);
            c.Simplify();
            return c;
        }
        public static Complex operator *(Complex c1 , Complex c2)
        {
            Complex c = new Complex(c1.up * c2.up, c2.down * c1.down);
            c.Simplify();
            return c;
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            Complex c = new Complex(c1.up * c2.down, c1.down * c2.up);
            c.Simplify();
            return c;
        }
        public override string ToString()
        {
            return up + "/" + down;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] arr = line.Split();
            string[] num = arr[0].Split('/');
            string[] num2 = arr[1].Split('/');
            Complex c1 = new Complex(int.Parse(num[0]), int.Parse(num[1]));
            Complex c2 = new Complex(int.Parse(num2[0]), int.Parse(num2[1]));
            Complex ans = c1 - c2;
            Console.WriteLine(ans);
            Complex an = c1 + c2;
            Console.WriteLine(an);
            Complex multiply = c1 * c2;
            Console.WriteLine(multiply);
            Complex divide = c1 / c2;
            Console.WriteLine(divide);
            Console.ReadKey();
        }
    }
}