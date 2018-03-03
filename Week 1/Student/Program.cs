using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        public string name;
        public string surname;
        public double gpa;
        
        public Student(string s, string d , double f)
        {
            name = s;
            surname = d;
            gpa = f;
        }
        public override string ToString()
        {
            return name + " " + surname + " " + gpa ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string d = Console.ReadLine();
            double i = Convert.ToDouble(Console.ReadLine());
            Student s = new Student(line,d,i);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
