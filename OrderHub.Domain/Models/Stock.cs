using OrderHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.DAL.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();


    }
}
