using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Exercise12.Model;

namespace Exercise12
{
    class Program
    {
        static void Main(string[] args)
        {
            FindCustomerByCity();
        }

        static void FindCustomerByCity()
        {
            string city;
            Console.WriteLine($"There are available cities:");
            using (var db = new Northwind())
            {
                IQueryable<string> availableCities = db.Customers
                    .Select(customer => customer.City)
                    .Distinct()
                    .Where(customerCity => customerCity != null)
                    .OrderBy(customerCity => customerCity);

                foreach(var availableCity in availableCities)
                {
                    Console.Write($"{availableCity}, ");
                }

                do
                {
                    Console.WriteLine("\n");
                    Console.Write("Enter name of the city: ");
                    city = Console.ReadLine();
                } while (!Array.Exists<string>(availableCities.ToArray(), element => element == city));

                IQueryable<Customer> customers = db.Customers
                    .Where(customer => customer.City == city);

                Console.WriteLine($"There are {customers.Count()} customers in {city}");

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.CompanyName}");
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                Console.WriteLine("Products that cost more than a price, and sorted.");
                string input;
                decimal price;
                do
                {
                    Console.Write("Enter a product price: ");
                    input = Console.ReadLine();
                } while (!decimal.TryParse(input, out price));
                IQueryable<Product> prods = db.Products
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost);
                foreach (Product item in prods)
                {
                    Console.WriteLine($"{item.ProductID}: {item.ProductName} costs {item.Cost:$#,##0.00} and has {item.Stock} units in stock.");
                }
            }
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                Console.WriteLine("Categories and how many products they have:");
                IQueryable<Category> cats = db.Categories.Include(c => c.Products);
                foreach (Category c in cats)
                {
                    Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }
    }
}
