using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x=>x.Src)
                .IsRequired();

            builder.Property(x => x.Alt)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
