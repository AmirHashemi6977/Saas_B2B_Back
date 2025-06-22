using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saas_B2B_Back.Persistence.Config
{
    public class RoleGroupConfig : IEntityTypeConfiguration<RoleGroup>
    {
        public void Configure(EntityTypeBuilder<RoleGroup> builder)
        {


            builder.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(x => x.Description)
                    .HasMaxLength(500);
        }
    }
}