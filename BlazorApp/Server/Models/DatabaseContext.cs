using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp.Server.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("userdetails");
                entity.Property(e => e.Userid).HasColumnName("Userid");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(100);
                entity.Property(e => e.LastName)
                    .HasMaxLength(100);
                entity.Property(e => e.Patronymic)
                    .HasMaxLength(100);
                entity.Property(e => e.LoginActiveDirectory)
                    .HasMaxLength(100);
                entity.Property(e => e.IsActive)
                    .HasMaxLength(1);
            });
        }
    }
}