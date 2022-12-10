namespace Module4HT4.Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
        public int PaymentId { get; set; }
        public PaymentEntity Payment { get; set; } = null!;
        public int ShipperId { get; set; }
        public ShipperEntity Shipper { get; set; } = null!;
        public int? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public List<OrderDetailsEntity> OrderDetails { get; set; } = null!;
    }
}
