using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructSample
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
    struct PointStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
