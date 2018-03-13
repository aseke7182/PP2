using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Product
    {
        public string s;
        public int n;
        public Product() { }
        public Product(string s, int n)
        {
            this.s = s;
            this.n = n;
        }
        public override string ToString()
        {
            return s + " " + n;
        }
    }
}
