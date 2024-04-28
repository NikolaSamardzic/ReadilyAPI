using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess.Configurations
{
    internal class DeliveryTypeConfiguration : NamedEntityConfiguration<DeliveryType>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<DeliveryType> builder)
        {

        }
    }
}
