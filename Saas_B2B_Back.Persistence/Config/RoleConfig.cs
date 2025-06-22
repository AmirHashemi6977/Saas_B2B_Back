using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saas_B2B_Back.Persistence.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {


            builder.Property(x => x.Name)
                    .HasMaxLength(20)
                    .IsRequired();

            builder.Property(x => x.Description)
                    .HasMaxLength(500);
        }
    }
}