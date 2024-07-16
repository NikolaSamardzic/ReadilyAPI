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
    internal class BookConfiguration : EntityConfiguration<Book>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Book> builder)
        {
            #region Properties
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.PageCount).IsRequired();

            builder.Property(x=>x.Price).HasPrecision(10, 2).IsRequired(false);

            builder.Property(x=>x.ReleaseDate).IsRequired();

            builder.Property(x=>x.AuthorId).IsRequired();
            #endregion

            #region Indexes
            builder.HasIndex(x => x.Title);

            builder.HasIndex(x => x.ReleaseDate);

            builder.HasIndex(x => x.Price);

            builder.HasIndex(x => x.AuthorId);
            #endregion

            #region Relations
            builder.HasOne(x=>x.Author)
                .WithMany(x=>x.Books)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Publisher)
                .WithMany(x=> x.Books)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x=>x.Image)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BookCategories)
                .WithOne(x => x.Book)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<Wishlist>()
                .WithOne(x=>x.Book)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<BookOrder>()
                .WithOne(x => x.Book)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
