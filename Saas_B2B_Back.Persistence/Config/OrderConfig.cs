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
    public class OrderConfig:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder) 
        {
            builder.Property(x => x.OrderStatus)
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(x => x.TotalPrice)
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(x => x.DeliveryDate)
                .HasMaxLength(200);
                

            builder.Property(x => x.UserId)
                 .HasMaxLength(50)
                 .IsRequired();


            builder.HasOne(x => x.User)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);

            builder.HasMany(x => x.OrderItems)
             .WithOne(x => x.Order)
             .HasForeignKey(x => x.OrderId)
             .HasPrincipalKey(x => x.Id);

          
        }
    }
}
