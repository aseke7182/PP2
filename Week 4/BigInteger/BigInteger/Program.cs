using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigInteger
{
    class BigInteger
    {
        string line;
        public BigInteger(string line)
        {
            this.line = line;
        }
        public static BigInteger operator +(BigInteger one , BigInteger two)
        {
            int raznica = 0;
            int minus = 0;
            string to ="";
            if(one.line[0]=='-' && two.line[0] == '-')
            {
                string s = "";
                for(int i=1; i<one.line.Length; i++)
                {
                    s = s + one.line[i];
                }
                one.line = s;
                 s = "";
                for (int i = 1; i < two.line.Length; i++)
                {
                    s = s + two.line[i];
                }
                two.line = s;

                minus = 1;
            }
            if(one.line.Length > two.line.Length)
            {
                raznica = one.line.Length - two.line.Length ;
                for (int i = 0; i < raznica; i++)
                {
                    to += "0"; 
                }
                two.line = to + two.line; 
            }
            if (one.line.Length < two.line.Length)
            {
                raznica = two.line.Length - one.line.Length ;
                for (int i = 0; i < raznica; i++)
                {
                    to += "0";
                }
                one.line = to + one.line;
            }
            if(one.line.Length==two.line.Length && one.line.Length == 1)
            {
                one.line = "0" + one.line;
                two.line = "0" + two.line;
            }
            int sum = 0;
            int adder = 0;
            string total = "";

            for(int i=one.line.Length-1; i>=0; i--)
            {
                sum = (int)(one.line[i]) + (int)(two.line[i])-96+adder;
                if (sum >= 10)
                {
                    adder = 1;
                    sum = sum - 10;
                }
                else
                {
                    adder = 0;
                }
                total  = total +sum;
            }

            string a = "";
            for(int i=total.Length-1; i >= 0; i--)
            {
                a += total[i];
            }
            total = a;
            if (total.Length == 2 && total[0]=='0')
            {
                total = total[1].ToString();
            }
            if(minus ==1)
            {
                total = '-' + total; 
            }
            BigInteger ans = new BigInteger(total);
            return ans;
        }
        public override string ToString()
        {
            return line;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
          
                string line = Console.ReadLine();
                string line2 = Console.ReadLine();
                BigInteger one = new BigInteger(line);
                BigInteger two = new BigInteger(line2);
                BigInteger sum = one + two;
            Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sum);
                Console.ReadKey();
            
        }
    }
}
