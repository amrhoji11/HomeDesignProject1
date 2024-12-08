using Landing.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Landing.DAL.Data
{
    public class ApplecationDbContext : IdentityDbContext<ApplecationUser>
    {
        public ApplecationDbContext(DbContextOptions<ApplecationDbContext> options)
            : base(options)
        {
        }
        //Seed Data 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           

           

            builder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>()
                .HasOne(c => c.Profile)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            // Seed Roles
            var RoleAdminId = Guid.NewGuid().ToString();
            var RoleSuperAdminId = Guid.NewGuid().ToString();
            var RoleUserId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = RoleAdminId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = RoleSuperAdminId, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole { Id = RoleUserId, Name = "User", NormalizedName = "USER" }
            );

            // Seed Users
            var hasher = new PasswordHasher<ApplecationUser>();
            var adminUserId = Guid.NewGuid().ToString();
            var superAdminUserId = Guid.NewGuid().ToString();
            var userUserId = Guid.NewGuid().ToString();

            var AdminUser = new ApplecationUser
            {
                Id = adminUserId,
                UserName = "admin@design.com",
                NormalizedUserName = "ADMIN@DESIGN.COM",
                Email = "admin@design.com",
                NormalizedEmail = "ADMIN@DESIGN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Amr@1212")
            };

            var SuperAdmin = new ApplecationUser
            {
                Id = superAdminUserId,
                UserName = "superadmin@design.com",
                NormalizedUserName = "SUPERADMIN@DESIGN.COM",
                Email = "superadmin@design.com",
                NormalizedEmail = "SUPERADMIN@DESIGN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Amr@1212")
            };

            var User = new ApplecationUser
            {
                Id = userUserId,
                UserName = "user@design.com",
                NormalizedUserName = "USER@DESIGN.COM",
                Email = "user@design.com",
                NormalizedEmail = "USER@DESIGN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Amr@1212")
            };

            builder.Entity<ApplecationUser>().HasData(AdminUser, SuperAdmin, User);

            // Seed UserRoles
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUserId, RoleId = RoleAdminId },
                new IdentityUserRole<string> { UserId = superAdminUserId, RoleId = RoleSuperAdminId },
                new IdentityUserRole<string> { UserId = userUserId, RoleId = RoleUserId }
            );

            // Seed Flaticons
            builder.Entity<Flaticon>().HasData(
                new Flaticon { Id = 1, Name = "kitchen" },
                new Flaticon { Id = 2, Name = "living-room" },
                new Flaticon { Id = 3, Name = "bathroom" },
                new Flaticon { Id = 4, Name = "garden" },
                new Flaticon { Id = 5, Name = "office" },
                new Flaticon { Id = 6, Name = "dining-room" },
                new Flaticon { Id = 7, Name = "balcony" }
            );
        }

        // DbSets
        public DbSet<Design> Designs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Social> socials { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<HomeLabel> HomeLabels { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Flaticon> flaticons { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<PProfile> profiles { get; set; }
        public DbSet<Massage> massages { get; set; }
        public DbSet<Blog> blogs { get; set; }
    }
}

