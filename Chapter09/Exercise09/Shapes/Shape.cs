using System.Xml.Serialization;

namespace Shapes
{
    public class Shape
    {
        [XmlAttribute("Colour")]
        public string Colour { get; set; }
        public readonly double Area;
        public Shape(string colour)
        {
            this.Colour = colour;
        }
        public Shape() {}
    }
}