using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<Account>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new() {
                    Id = "00000000-0000-0000-0000-000000000001",
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000002"
                },
                new(){
                    Id = "00000000-0000-0000-0000-000000000003",
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000004"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}