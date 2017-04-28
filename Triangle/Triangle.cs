using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    enum TriangleType
    {
        Equilateral,
        Isosceles,
        None
    }
    class Triangle
    {
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public int Side3 { get; set; }

        public Triangle(int Side1, int Side2, int Side3)
        {
            this.Side1 = Side1;
            this.Side2 = Side2;
            this.Side3 = Side3;
        }
        private bool isEquilateral()
        {
            return Side1 == Side2 && Side2 == Side3;
        }
        private bool isIsosceles()
        {
            if (Side1 == Side2 || Side2 == Side3 || Side1 == Side3)
                return true;
            return false;
        }
        public TriangleType GetType()
        {
            if (isEquilateral())
                return TriangleType.Equilateral;
            if (isIsosceles())
                return TriangleType.Isosceles;
            return TriangleType.None;
        }
    }
}
