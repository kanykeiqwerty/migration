using Microsoft.EntityFrameworkCore;
using MigrationApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MigrationApi.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CitizenForm> CitizenForms { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Migration> Migrations { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Role> Roles { get; set; }
        // public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleID);

            modelBuilder.Entity<Migration>(builder =>
        {
            builder.Property(m => m.DepartureDate)
                   .HasColumnType("date");

            builder.Property(m => m.ReturnDate)
                   .HasColumnType("date");


        });
        }
    }
}