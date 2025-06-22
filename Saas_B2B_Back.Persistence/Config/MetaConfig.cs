using Microsoft.EntityFrameworkCore;
using Saas_B2B_Back.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saas_B2B_Back.Persistence.Config
{
    public class MetaConfig:IEntityTypeConfiguration<Meta>
    {
        public void Configure(EntityTypeBuilder<Meta> builder)
        {
            builder.Property(x => x.Title)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(5000);

            builder.HasMany(x => x.MetaJunc)
                .WithOne(x => x.Meta)
                .HasForeignKey(x => x.MetaId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
