using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Rectangle
    {
        public double width;
        public double height;
        public double area;
        public double perimeter ;

        public Rectangle(double w, double h)
        {
            width = w;
            height = h;
            FindArea();
            FindPerimeter();
        }
        public void FindArea()
        {
            area = width * height;
        }
        public void FindPerimeter()
        {
            perimeter = (width + height) * 2;
        }
        public override string ToString()
        {
            return "area = " + area + "\nperimeter = " + perimeter  ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Rectangle m = new Rectangle(width, height);
            Console.WriteLine(m);
            Console.ReadKey();
        }
    }
}
