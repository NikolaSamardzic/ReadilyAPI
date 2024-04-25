using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class CommentConfiguration : EntityConfiguration<Comment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Comment> builder)
        {
            #region Properties
            builder.Property(x=>x.Text).IsRequired().HasMaxLength(500);
            #endregion

            #region Relations
            builder.HasOne(x => x.User)
                .WithMany(x => x.Comments);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Comments);

            builder.HasMany(x => x.Images)
                .WithMany()
                .UsingEntity<CommentImage>();
            #endregion
        }
    }
}
