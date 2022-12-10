namespace Module4HT4.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Picture { get; set; } = null!;
        public bool Active { get; set; }
        public List<ProductEntity> Products { get; set; } = null!;
    }
}
