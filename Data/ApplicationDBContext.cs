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
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new(){
                    Name = "user",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}