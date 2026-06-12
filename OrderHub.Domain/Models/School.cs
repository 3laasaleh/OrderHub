using OrderHub.Domain.Enums;


namespace OrderHub.DAL.Domain.Models
{
    public class School
    {
        public int Id { get; set; }
        public TierCodeType TierCode { get; set; } = TierCodeType.Silver;
        public string Name { get; set; } = string.Empty;
    }
}
