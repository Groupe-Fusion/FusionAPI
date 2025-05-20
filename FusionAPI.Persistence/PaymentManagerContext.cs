using FusionAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence
{
    public class PaymentManagerContext(DbContextOptions<PaymentManagerContext> options)
        : DbContext(options)
    {
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentId);
        }
    }
}
