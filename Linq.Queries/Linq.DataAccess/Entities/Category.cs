using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.DataAccess.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
    }
}
