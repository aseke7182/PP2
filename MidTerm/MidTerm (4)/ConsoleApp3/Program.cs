using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo df = new DirectoryInfo(@"C:\Users\Askar\Desktop\ConsoleApp3\ConsoleApp3\bin\Debug");
            FileInfo[] fileInfo = df.GetFiles();
            for(int i = 0; i < fileInfo.Length; i++)
            {
                for(int j = 0; j < fileInfo[i].Length; j++)
                {
                    
                }
                Console.WriteLine(fileInfo[i]);
            }
            Console.ReadKey();
        }
    }
}
