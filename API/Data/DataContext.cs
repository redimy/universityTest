using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<AppUser>()
                .HasMany(ur => ur.Groups)
                .WithOne(u => u.AppUser)
                .HasForeignKey(ur => ur.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Group>()
                .HasMany(ur => ur.Assignments)
                .WithOne(u => u.Group)
                .HasForeignKey(ur => ur.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Assignment>()
                .HasMany(ur => ur.Grades)
                .WithOne(u => u.assignment)
                .HasForeignKey(ur => ur.assignmentId)
                .OnDelete(DeleteBehavior.Cascade);

             builder.Entity<Grade>()
                .HasOne(ur => ur.assignment)
                .WithMany(u => u.Grades)
                .HasForeignKey(ur => ur.assignmentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}