using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Saas_B2B_Back.Persistence.Config
{
    public class PermissionRoleConfig : IEntityTypeConfiguration<PermissionRole>
    {
        public void Configure(EntityTypeBuilder<PermissionRole> builder)
        {
            builder
             .HasOne(pr => pr.Role)
             .WithMany(r => r.PermissionRoles)
             .HasForeignKey(pr => pr.RoleId);

            builder
                .HasOne(pr => pr.Permission)
                .WithMany(p => p.PermissionRoles)
                .HasForeignKey(pr => pr.PermissionId);
        }
    }
}
