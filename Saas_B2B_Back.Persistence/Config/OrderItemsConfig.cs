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
    public class OrderItemsConfig:IEntityTypeConfiguration<OrderItems>
    {

        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            

            builder.Property(x => x.Quantity)
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(x => x.Unit)
                .HasMaxLength(20)
                .IsRequired();


            builder.Property(x => x.UnitPrice)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Amount)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.Property(x => x.DiscountPercent)
                 .HasMaxLength(5);

            builder.Property(x => x.DiscountAmount)
                 .HasMaxLength(50);

            builder.Property(x => x.TaxAmount)
                 .HasMaxLength(50);

            builder.Property(x => x.NetAmount)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.Property(x => x.ExtraAmount)
                 .HasMaxLength(50);

            builder.Property(x => x.PayableAmount)
                 .HasMaxLength(50)
                 .IsRequired();


            builder.Property(x => x.UpdateDate)
                 .HasMaxLength(200);
                

            builder.HasOne(x => x.Order)
             .WithMany(x => x.OrderItems)
             .HasForeignKey(x => x.OrderId)
             .HasPrincipalKey(x => x.Id);


            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x=>x.ProductId)
                .HasPrincipalKey (x => x.Id);

        
                
        }
    }
}
