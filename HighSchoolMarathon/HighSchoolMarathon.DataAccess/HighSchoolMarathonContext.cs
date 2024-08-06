using HighSchoolMarathon.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HighSchoolMarathon.DataAccess
{
    public class HighSchoolMarathonContext : IdentityDbContext
    {
        public HighSchoolMarathonContext(DbContextOptions<HighSchoolMarathonContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<RunnerRegistration> RunnerRegistrations { get; set; }

        //public DbSet<Organizer> Organizers { get; set; }

        public DbSet<RunningEvent> RunningEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial IdentityUsers
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!")
            };

            var adminRole = new IdentityRole
            {
                Id = "6CCD5657-FAA2-4CC8-ACD9-71145E60BE9E",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            modelBuilder.Entity<IdentityUser>().HasData(adminUser);
            modelBuilder.Entity<IdentityRole>().HasData(adminRole);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            });
        }
    }
}