using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(1, 2);
            ChangeX(point);
            Console.WriteLine(point.X + " " + point.Y);

            PointStruct points = new PointStruct(3, 4);
            ChangeX(ref points);
            Console.WriteLine(points.X + " " + points.Y);
        }

        static void ChangeX(Point p)
        {
            p.X = 5;
        }

        static void ChangeX(ref PointStruct p)
        {
            p.X = 5;
        }
    }
}
