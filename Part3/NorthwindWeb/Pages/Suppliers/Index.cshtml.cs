using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using NorthwindContextLib;
using NorthwindEntitiesLib;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private Northwind db;

        public IEnumerable<Supplier> Suppliers { get; set; }
        [BindProperty]
        public Supplier Supplier { get; set; }

        public IndexModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = db.Suppliers.ToArray();
        }
    }
}