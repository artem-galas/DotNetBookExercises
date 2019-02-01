using System;

namespace ShapeLibrary
{
    public class Square : Shape
    {
        public double Width;
        public Square(double width)
        {
            this.Width = width;
        }
        public override double Area()
        {
            return Area(Width);
        }

        public static double Area(double width)
        {
            return Math.Pow(width, 2);
        }
    }
}