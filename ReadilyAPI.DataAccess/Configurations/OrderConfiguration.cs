using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class OrderConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            #region Properties
            builder.Property(x => x.FinishedAt)
                .IsRequired(false);

            builder.Property(x=>x.TotalPrice).HasPrecision(10,2);
            #endregion

            #region Relations
            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.BookOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
            #endregion
        }
    }
}
