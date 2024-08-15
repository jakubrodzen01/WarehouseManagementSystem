using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Models;

namespace WarehouseManagementSystem
{
    public class DbWarehouseContext : IdentityDbContext<UserModel>
    {
        public DbWarehouseContext(DbContextOptions<DbWarehouseContext> options) : base(options) { }

        //public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
