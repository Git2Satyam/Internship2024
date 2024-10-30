using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Core.DataModels
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public bool? isActive { get; set; }
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User Users { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
