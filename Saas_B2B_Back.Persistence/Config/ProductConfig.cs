using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Persistence.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(5000);

            builder.HasOne(x => x.Detail)
                .WithOne(x => x.Product)
                .HasForeignKey<ProductDetail>(x => x.ProductId)
                .HasPrincipalKey<Product>(x => x.Id);

            builder.HasMany(x => x.MetaJunc)
             .WithOne(x => x.Product)
             .HasForeignKey(x => x.ProductId)
             .HasPrincipalKey(x => x.Id);

            builder.HasMany(x => x.Images)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .HasPrincipalKey(x => x.Id);


        }
    }
}
