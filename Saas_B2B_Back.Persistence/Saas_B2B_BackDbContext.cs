using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using Saas_B2B_Back.Persistence.Config;
using Microsoft.EntityFrameworkCore;


namespace Saas_B2B_Back.Persistence
{
    public class Saas_B2B_BackDbContext : DbContext
    {
        public Saas_B2B_BackDbContext(DbContextOptions<Saas_B2B_BackDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<ProductImages> ProductImages { get; set; }

        public DbSet<Meta> Meta { get; set; }

        public DbSet<MetaJunc> MetaJunc { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<OrderItems> ordersItems { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<PermissionRole> PermissionRole { get; set; }

        public DbSet<RoleGroup> RoleGroups { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }


        public DbSet<UserGroup> UserGroups { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);


            modelBuilder.Entity<UserGroup>().HasData(
              new UserGroup { Id = 1, Name = "مشتری", Description = "Customers of the system" },
             new UserGroup { Id = 2, Name = "فروشنده", Description = "Sellers who provide products" },
                new UserGroup { Id = 3, Name = "مدیریت", Description = "System administrators" }
                 );
        }

    }
}