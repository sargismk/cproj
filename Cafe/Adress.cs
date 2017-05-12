using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace Cafe
{
    class Adress
    {
        public String city { set; get; }
        public String street { set; get; }
        public int num { set; get; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public GeoCoordinate coord;

        public Adress(String city, String street, int num, double latitude, double longitude)
        {
            this.city = city;
            this.street = street;
            this.num = num;
            coord = new GeoCoordinate(latitude, longitude);
        }
    }
}