using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HT4.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; } = null!;
        public int? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = null!;
    }
}
