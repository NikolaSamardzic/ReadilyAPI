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

            #region Relations
            builder.HasOne<User>()
                .WithMany(x=>x.Reviews)
                .HasForeignKey(x=>x.UserId);

            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey(x=>x.BookId);
            #endregion
        }
    }
}
