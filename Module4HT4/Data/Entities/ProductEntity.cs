namespace Module4HT4.Data.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;
        public int SupplierId { get; set; }
        public SupplierEntity Supplier { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public List<OrderDetailsEntity> OrderDetails { get; set; } = null!;
    }
}
