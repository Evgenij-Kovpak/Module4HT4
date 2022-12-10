using Module4HT4.Data.Entities;

namespace Module4HT4.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = null!;
    }
}
