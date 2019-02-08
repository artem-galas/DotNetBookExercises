using System;
using System.Xml.Serialization;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(string colour, double radius) : base(colour)
        {
            this.Radius = radius;
        }
        public Circle() : base() { }

        [XmlAttribute("Radius")]
        public double Radius { get; set; }
        [XmlAttribute("Area")]
        public new double Area
        {
            get
            {
                return Math.Round(Math.PI * Math.Pow(Radius, 2), 1);
            }
            set {}
        }
    }
}