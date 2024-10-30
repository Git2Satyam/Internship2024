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
    public class CartMapConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
           builder.HasKey(x => x.Id);
            builder.HasOne(c => c.Users).WithOne(c => c.Carts).HasForeignKey<Cart>(c => c.UserId);
        }
    }
}
