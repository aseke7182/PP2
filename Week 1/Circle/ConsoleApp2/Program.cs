using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Circle
    {
        public double radius;
        public double area;
        public double diameter;
        public double circumference;
        
        public Circle(double r)
        {
            radius = r;
            FindArea();
            FindDiameter();
            FindCircumference();
        }
        public void FindArea()
        {
            area = Math.PI * radius * radius;
        }
        public void FindDiameter()
        {
            diameter = radius * 2;
        }
        public void FindCircumference()
        {
            circumference = 2 * Math.PI * radius;
        }
        public override string ToString()
        {
            return "area = " + area + "\ndiameter = " + diameter + "\ncircumference = " + circumference ;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            Circle c = new Circle(radius);
            Console.WriteLine(c);
            Console.ReadKey();
        }
    }
}
