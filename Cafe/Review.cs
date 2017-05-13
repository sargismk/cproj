using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class Review
    {
        public String user { get; set; }
        public String rate { get; set; }
        public String comment { get; set; }

        public Review(String user, String rate, String comment)
        {
            this.user = user;
            this.rate = rate;
            this.comment = comment;
        }
        public void RevPrint()
        {
            Console.WriteLine("User: " + user + "\n" + "Rate: " + rate + "\n" + "Comment about cafe: " + comment + "\n");
        }
    }
}