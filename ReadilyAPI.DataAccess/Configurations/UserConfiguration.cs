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
    internal class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            #region Properties
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.IsBanned)
                .HasDefaultValue(false);
            #endregion

            #region Indexes
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x=>x.Username)
                .IsUnique();

            builder.HasIndex(x => x.RoleId);
            #endregion

            #region Relations
            builder.HasOne(x=> x.Avatar)
                .WithMany()
                .HasForeignKey(x=>x.AvatarId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Address)
                .WithMany()
                .HasForeignKey(x=>x.AddressId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x=>x.Role)
                .WithMany()
                .HasForeignKey(x=>x.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Biography)
                .WithOne()
                .HasForeignKey<Biography>(x => x.UserId)
                .IsRequired();

            builder.HasMany(x=>x.Categories)
                .WithMany()
                .UsingEntity<UserCategory>();
            #endregion
        }
    }
}
