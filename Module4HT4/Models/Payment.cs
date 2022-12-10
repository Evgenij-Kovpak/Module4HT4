using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HT4.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public bool Allowed { get; set; }
        public List<Order> Orders { get; set; } = null!;
    }
}
