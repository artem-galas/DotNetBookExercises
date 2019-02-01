using System;

namespace ShapeLibrary
{
    public class Circle : Shape
    {
        public double Radius;
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override double Area()
        {
            return Area(Radius);
        }

        public static double Area(double radius)
        {
            return Math.Round(Math.PI * Math.Pow(radius, 2), 1);
        }
    }
}