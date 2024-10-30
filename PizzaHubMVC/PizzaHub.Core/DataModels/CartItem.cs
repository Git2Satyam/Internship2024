using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Core.DataModels
{
    public class CartItem
    {
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool? isActive { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart Carts { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
    }
}
