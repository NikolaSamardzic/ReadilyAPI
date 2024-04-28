using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class MessageConfiguration : EntityConfiguration<Message>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Message> builder)
        {
            #region Properties
            builder.Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(1000);
            #endregion

            #region Relations
            builder.HasOne(x => x.User)
                .WithMany(x => x.Messages)
                .IsRequired();
            #endregion
        }
    }
}
