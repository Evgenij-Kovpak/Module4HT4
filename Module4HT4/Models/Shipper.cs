namespace Module4HT4.Models
{
    public class Shipper
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public List<Order> Orders { get; set; } = null!;
    }
}
