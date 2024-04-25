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
    internal class PriceConfiguration : EntityConfiguration<Price>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Price> builder)
        {
            #region Properties
            builder.Property(x => x.Value)
                .IsRequired()
                .HasPrecision(10, 2);
            #endregion

            #region Relations
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Prices)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.BookId); 
            #endregion
        }
    }
}
