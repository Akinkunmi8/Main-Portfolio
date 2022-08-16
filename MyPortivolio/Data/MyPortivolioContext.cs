using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortivolio.Models;

namespace MyPortivolio.Data
{
    public class MyPortivolioContext : IdentityDbContext<IdentityUser>
    {
        public MyPortivolioContext(DbContextOptions<MyPortivolioContext>options) : base(options)
        {
              
        }
        public DbSet<Contacts> contacts { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<UserModel> userModels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Member", NormalizedName = "MEMBER"},
                    new IdentityRole { Name ="Admin", NormalizedName = " ADMIN" }

                );
        }
    }
}
