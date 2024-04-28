using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class BiographyConfiguration : EntityConfiguration<Biography>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Biography> builder)
        {
            #region Properties
            builder.Property(x => x.Text)
                    .IsRequired()
                    .HasMaxLength(1000);
            #endregion
        }
    }
}
