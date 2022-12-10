namespace Module4HT4.Data.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public bool Allowed { get; set; }
        public List<OrderEntity> Orders { get; set; } = null!;
    }
}
