using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadToEnd();
            string[] ss = s.Split(' ');
            int min = int.Parse(ss[0]);
            
            for (int i = 0; i < ss.Count()-1; i++)
            {
                if (int.Parse(ss[i]) < min)
                {
                    min = int.Parse(ss[i]);
                }
            }
            
            for (int i = 0; i < ss.Count() ; i++)
            {
                if (int.Parse(ss[i]) == min)
                {
                    continue; 
                }
                if (int.Parse(ss[i]) < ans)
                {
                    ans = int.Parse(ss[i]);
                }
            }
            sr.Close();
            File.WriteAllText("output.txt", ans.ToString());

        }
    }
}
