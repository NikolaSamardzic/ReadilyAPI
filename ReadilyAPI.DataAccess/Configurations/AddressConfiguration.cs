using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class AddressConfiguration : EntityConfiguration<Address>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Address> builder)
        {
            #region Properties
            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.AddressName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.AddressNumber)
                .IsRequired()
                .HasMaxLength(50);
            #endregion

            #region Indexes
            builder.HasIndex(x => new { 
                x.Country, 
                x.State, 
                x.City, 
                x.PostalCode, 
                x.AddressName, 
                x.AddressNumber 
            });
            #endregion
        }
    }
}
