namespace OrderHub.DAL.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Embroidery { get; set; } = string.Empty;

        public int SchoolId { get; set; }
        public School? School { get; set; }
    }
}
