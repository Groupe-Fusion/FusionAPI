using FusionAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence
{
    public class UserManagerContext(DbContextOptions<UserManagerContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);
        }
    }
}
