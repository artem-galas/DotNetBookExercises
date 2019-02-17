using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Exercise12.Model
{
    public class Customer
    {
        public string CustomerID {get; set;}
        [Required]
        [StringLength(40)]
        public string CompanyName {get; set;}
        [StringLength(30)]
        public string ContactName {get; set;}
        public string ContactTitle {get; set;}
        public string Address {get; set;}
        public string City {get; set;}
        public string PostalCode {get; set;}
        public string Country {get; set;}
        public string Phone {get; set;}
    }
}