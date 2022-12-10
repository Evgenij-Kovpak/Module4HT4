using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HT4.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public List<Order> Orders { get; set; } = new ();
    }
}
