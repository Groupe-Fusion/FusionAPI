using FusionAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence
{
    public class EvaluationManagerContext(DbContextOptions<EvaluationManagerContext> options) : DbContext(options)
    {
        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Evaluation>()
				.HasKey(e => e.Id);
		}
	}
}
