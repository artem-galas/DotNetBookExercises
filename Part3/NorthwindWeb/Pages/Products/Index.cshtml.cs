using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using NorthwindContextLib;
using NorthwindEntitiesLib;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages.Products
{
    public class IndexModel : PageModel
    {
        private Northwind db;

        public IEnumerable<Product> Products { get; set; }
        public IndexModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Products";
            Products = db.Products.ToArray();
        }
    }
}