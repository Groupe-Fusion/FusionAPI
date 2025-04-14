using FusionAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence
{
    public class UserManagerContext(DbContextOptions<UserManagerContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.CreatedBy)
                .WithMany(u => u.Reservations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(b => b.Reservations)
                .WithOne(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
