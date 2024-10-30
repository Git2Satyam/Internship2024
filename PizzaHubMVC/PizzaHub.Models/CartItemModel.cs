using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int? Qunatity { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool? isActive { get; set; }
    }
}
