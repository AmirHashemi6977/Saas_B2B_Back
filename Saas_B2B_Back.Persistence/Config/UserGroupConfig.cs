using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saas_B2B_Back.Persistence.Config
{
    internal class UserGroupConfig : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {


            builder.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(x => x.Description)
                    .HasMaxLength(500);
        }
    }
}