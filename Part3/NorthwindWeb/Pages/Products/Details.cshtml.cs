using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using NorthwindContextLib;
using NorthwindEntitiesLib;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private Northwind db;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Product Product {get; set;}

        public DetailsModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet(int id)
        {
            Id = id;
            Product = db.Products.Find(Id);
            ViewData["Title"] =  $"Product - {Product.ProductName}";
        }
    }
}