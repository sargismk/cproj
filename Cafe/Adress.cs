using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class Adress
    {
        public String city { set; get; }
        public String street { set; get; }
        public int num { set; get; }

        public Adress(String city, String street, int num)
        {
            this.city = city;
            this.street = street;
            this.num = num;
        }
    }
}
