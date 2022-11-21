using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.DataAccess.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; } 

        public Orders()
        {
            this.OrderId = 0;
        }
    }
}
