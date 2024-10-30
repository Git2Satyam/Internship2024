using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Models
{
    public class CartModel
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public bool? isActive { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ProductModel Product { get; set; }
    }
}
