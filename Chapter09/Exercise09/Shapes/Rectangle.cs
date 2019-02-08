using System;
using System.Xml.Serialization;

namespace Shapes
{
    public class Rectangle : Shape
    {
        [XmlAttribute("Width")]
        public double Width { get; set; }
        [XmlAttribute("Height")]
        public double Height { get; set; }
        [XmlAttribute("Area")]
        public new double Area
        {
            get
            {
                return Width * Height;
            }
            set {}
        }
        public Rectangle(string colour, double width, double height) : base(colour)
        {
            this.Colour = colour;
            this.Width = width;
            this.Height = height;
        }

        public Rectangle() : base() { }
    }
}