using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.DataAccess.Entities
{
    public class Shippers
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
