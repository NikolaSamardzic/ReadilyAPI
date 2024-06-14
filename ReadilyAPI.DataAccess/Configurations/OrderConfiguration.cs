using Microsoft.EntityFrameworkCore;
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

            builder.Property(x=>x.AddressId).IsRequired(false);

            builder.Property(x=>x.TotalPrice).HasPrecision(10,2);

            builder.Property(x => x.TotalPrice).HasDefaultValue(0.00);
            #endregion

            #region Relations
            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BookOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
                .WithMany(x=>x.Orders)
                .HasForeignKey(x => x.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DeliveryType)
                .WithMany(x=>x.Orders)
                .HasForeignKey(x => x.DeliveryTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
