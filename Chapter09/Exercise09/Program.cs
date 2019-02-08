using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using Shapes;
using Newtonsoft.Json;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace Exercise09
{
    class Program
    {

        static List<Shape> Shapes = new List<Shape> {
            new Circle(colour: "Red", radius: 2.5),
            new Circle(colour: "Purple", radius: 12.3),
            new Circle(colour: "Green", radius: 8),
            new Rectangle(colour: "Blue", width: 12, height: 2.4),
            new Rectangle(colour: "Yellow", width: 4.3, height: 15.2),
        };

        static void Main(string[] args)
        {
            CreateXmlOfShapes();
            CreateJsonOfShapes();
            DeserializeXMLOfShapes();
        }

        static void CreateXmlOfShapes()
        {
            string xmlPath = Combine(CurrentDirectory, "shapes.xml");
            FileStream fs = File.Create(xmlPath);
            var xs = new XmlSerializer(
                typeof(List<Shape>),
                new Type[]
                {
                    typeof(List<Circle>),
                    typeof(List<Rectangle>)
                }
            );
            xs.Serialize(fs, Shapes);
            fs.Close();

            Console.WriteLine($"Written {new FileInfo(xmlPath).Length} bytes of XML to {xmlPath}");
        }

        static void CreateJsonOfShapes()
        {
            var jsonPath = Combine(CurrentDirectory, "shapes.json");
            StreamWriter sw = File.CreateText(jsonPath);
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Serialize(sw, Shapes);

            sw.Close();
            Console.WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of JSON to {jsonPath}");
        }

        static void DeserializeXMLOfShapes()
        {
            string xmlPath = Combine(CurrentDirectory, "shapes.xml");
            FileStream xmlLoad = File.Open(xmlPath, FileMode.Open);
            var xs = new XmlSerializer(
                typeof(List<Shape>),
                new Type[]
                {
                    typeof(List<Circle>),
                    typeof(List<Rectangle>)
                }
            );
            List<Shape> loadedShapesXml = (List<Shape>)xs.Deserialize(xmlLoad);

            foreach(Shape item in loadedShapesXml)
            {
                Console.WriteLine($"{item.GetType().Name} is {item.Colour} and has an area of {item.Area}");
            }
        }
    }
}
