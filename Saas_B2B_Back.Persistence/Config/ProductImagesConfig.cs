using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Persistence.Config
{
    public class ProductImagesConfig:IEntityTypeConfiguration<ProductImages>
    {
        public void Configure(EntityTypeBuilder<ProductImages> builder)
        {
            builder.Property(x => x.Url)
                .HasMaxLength(500);

            builder.Property(x => x.Title)
                .HasMaxLength(1000);

        }
    }
}
