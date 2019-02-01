using System;

namespace ShapeLibrary
{
    public class Rectangle : Shape
    {
        public double Width;
        public double Height;
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double Area()
        {
            return Area(Width, Height);
        }

        public static double Area(double width, double height)
        {
            return width * height;
        }
    }
}