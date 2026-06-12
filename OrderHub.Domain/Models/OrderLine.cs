using OrderHub.Domain.Enums;
using OrderHub.Domain.Models;


namespace OrderHub.DAL.Domain.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public long Quantity { get; set; } 
        public string Embroidery { get; set; } = string.Empty;
        public List<Product>? Products { get; set; } 


    }
}
