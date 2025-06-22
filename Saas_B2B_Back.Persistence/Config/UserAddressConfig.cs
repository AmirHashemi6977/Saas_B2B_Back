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
    public class UserAddressConfig:IEntityTypeConfiguration<UserAddress>
    {
        public void Configure( EntityTypeBuilder<UserAddress> builder) 
        {

            builder.Property(x => x.Address)
                .HasMaxLength(1000);

            builder.Property(x => x.City)
                .HasMaxLength(50);

            builder.Property(x=>x.Area)
                .HasMaxLength(50);

            builder.Property(x=>x.PostalCode)
                .HasMaxLength(20);
        }

    }
}
