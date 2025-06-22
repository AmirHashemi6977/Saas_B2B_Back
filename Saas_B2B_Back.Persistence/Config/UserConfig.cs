using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Saas_B2B_Back.Persistence.Config
{
    public class UserConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Firstname)
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(x => x.Lastname)
            .HasMaxLength(300)
            .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(200);


            builder.Property(x => x.NationalCode)
            .HasMaxLength(11);


            builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();


            builder.Property(x => x.PasswordHash)
            .HasMaxLength(500)
            .IsRequired();

            builder.HasMany(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);

            //builder.HasMany(x => x.Roles)
            //  .WithOne(x => x.User)
            //  .HasForeignKey(x => x.UserId)
            //  .HasPrincipalKey(x => x.Id);


        }


    }
}
