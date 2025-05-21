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
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(b => b.Reservations)
                .WithOne(r => r.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Prestataire)
                .WithMany(p => p.Prestations)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
