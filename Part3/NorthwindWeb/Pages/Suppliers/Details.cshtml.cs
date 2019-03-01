using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using NorthwindContextLib;
using NorthwindEntitiesLib;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private Northwind db;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Supplier Supplier {get; set;}

        public DetailsModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet(int id)
        {
            Id = id;
            Supplier = db.Suppliers.Find(Id);
            Console.WriteLine(Supplier);
            ViewData["Title"] =  $"Supplier - {Supplier.CompanyName}";
        }
    }
}