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
    public class ProductDetailsConfig:IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.Property(x => x.Dimension)
                .HasMaxLength(50);

            builder.Property(x => x.Weight)
               .HasMaxLength(50);

            builder.Property(x => x.WatteringAmount)
               .HasMaxLength(50);

            builder.Property(x => x.WatteringMethod)
               .HasMaxLength(500);

            builder.Property(x => x.SunAmount)
               .HasMaxLength(50);


            builder.Property(x => x.Material)
               .HasMaxLength(50);

            builder.Property(x => x.Color)
            .HasMaxLength(50);

            builder.Property(x => x.Description)
            .HasMaxLength(1000);


        }

    }
}
