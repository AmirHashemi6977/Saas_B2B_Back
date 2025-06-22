using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saas_B2B_Back.Persistence.Config
{
    internal class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {


            builder.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(x => x.Description)
                    .HasMaxLength(500);
        }
    }
}