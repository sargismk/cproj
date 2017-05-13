using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class Cafes
    {
        public String name { get; set; }
        public Adress adress { get; set; }
        public String web { get; set; }
        public String number { get; set; }
        public String openTimes { get; set; }
        public List<Review> reviews { get; set; }

        public Cafes(String name, Adress adress, String web, String number, String openTimes)
        {
            this.name = name;
            this.adress = adress;
            this.web = web;
            this.number = number;
            this.openTimes = openTimes;
            reviews = new List<Review>();
        }
        public void Print()
        {
            Console.WriteLine(this.name + "\n" + "Adress:" + this.adress.city + " " + this.adress.street + " "
                        + this.adress.num + "\n" + "Web adress:" + this.web + "\n" + "Phone number:" + this.number + "\n" + "Open at:" + this.openTimes);
            Console.WriteLine("Reviews about " + this.name + ": \n");
            foreach (Review review in this.reviews)
            {
                if (this.reviews.Count != 0)
                {
                    review.RevPrint();
                }
                else
                    Console.WriteLine("There are no reviews yet!");
            }
        }
    }
}