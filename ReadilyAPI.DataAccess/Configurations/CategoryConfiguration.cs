using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            #region Properties
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            #endregion

            #region Indexes
            builder.HasIndex(x => x.Name)
                .IsUnique(); 
            #endregion
        }
    }
}
