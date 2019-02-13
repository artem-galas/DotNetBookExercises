using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Exercise10
{
    class Program
    {
        static List<Customer> customers = new List<Customer>() {
            Customer.Register("Artem", "Halas", "1234567", cardNumber: "4242424242"),
            Customer.Register("John", "Snow", "ImAKing", cardNumber: "5566556655"),
            Customer.Register("Han", "Solo", "LoveLeia", cardNumber: "0998877654")
        };
        static void Main(string[] args)
        {
            WriteToXml(customers);
            Console.WriteLine("See cusomers.xml document");
            Console.WriteLine();
            Console.WriteLine("Press enter for Decrypt");
            Console.ReadLine();

            string xmlPath = Path.Combine(Environment.CurrentDirectory, "customers.xml");
            FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fs);
                XmlNodeList customersNodes = doc.DocumentElement.SelectNodes("/Customers/Customer");

                foreach (XmlNode customerNode in customersNodes)
                {
                    string customerCardNumber = customerNode.Attributes["CardNumber"].Value;
                    string customerName = customerNode.InnerText;
                    string customerSalt = customerNode.Attributes["Salt"].Value;
                    string customerHashedPassword = customerNode.Attributes["Password"].Value;
                    var customer = new Customer(fullName: customerName)
                    {
                        Salt = customerSalt,
                        HashedPassword = customerHashedPassword
                    };

                    Console.WriteLine($"Please provide a password for a user {customer.Name}");
                    var password = Console.ReadLine();

                    string decryptCardNumber = customer.DecryptCardNumber(customerCardNumber, password);

                    Console.WriteLine($"{customer.Name} have card {decryptCardNumber}");
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        static void WriteToXml(List<Customer> customers)
        {
            string xmlPath = Path.Combine(Environment.CurrentDirectory, "customers.xml");
            XmlWriter xmlWriter = XmlWriter.Create(xmlPath);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Customers");

            foreach (var customer in customers)
            {
                xmlWriter.WriteStartElement("Customer");

                xmlWriter.WriteAttributeString("Password", customer.HashedPassword);
                xmlWriter.WriteAttributeString("CardNumber", customer.BcryptCardNumber);
                xmlWriter.WriteAttributeString("Salt", customer.Salt);
                xmlWriter.WriteString(customer.Name);

                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }
    }
}
