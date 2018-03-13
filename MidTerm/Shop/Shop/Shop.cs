using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Shop
    {
        public List<Product> list;
        public Shop() { }
        public Shop(List<Product> list)
        {
            this.list = list;
        }
    }
}
