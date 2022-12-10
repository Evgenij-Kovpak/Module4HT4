namespace Module4HT4.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ContactFName { get; set; } = null!;
        public string ContactLName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public List<Product> Products { get; set; } = null!;
    }
}
