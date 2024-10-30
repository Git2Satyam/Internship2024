using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaHub.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Core.Config
{
    public class CartItemMapConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(t => t.Carts).WithMany(t => t.CartItems).HasForeignKey(t => t.CartId);
            builder.HasOne(c => c.Products).WithOne(c => c.CartItems).HasForeignKey<CartItem>(c => c.ProductId);
        }
    }
}
