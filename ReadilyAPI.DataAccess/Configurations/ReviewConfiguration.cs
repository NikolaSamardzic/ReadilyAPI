using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class ReviewConfiguration : EntityConfiguration<Review>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Review> builder)
        {
            #region Properties
            builder.Property(x => x.Stars)
                .IsRequired();
            #endregion

            #region Indexes
            builder.HasIndex(x => new { x.UserId, x.BookId })
                .IsUnique();
            #endregion

            #region Relations
            builder.HasOne(x => x.User)
                .WithMany(x=>x.Reviews)
                .HasForeignKey(x=>x.UserId);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x=>x.BookId);
            #endregion
        }
    }
}
