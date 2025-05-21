using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace FusionAPI.Persistence.Repositories
{
    public class EvaluationRepository(EvaluationManagerContext _context) : IEvaluationRepository
    {
        public async Task<IList<Evaluation>> GetAllEvaluationsAsync(CancellationToken ct = default)
        {
            return await _context.Evaluations.ToListAsync(ct);
        }

        public async Task<Evaluation?> GetEvaluationByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Evaluations.FindAsync(new object[] { id }, ct);
        }

        public async Task<Evaluation> AddEvaluationAsync(Evaluation evaluation, CancellationToken ct = default)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync(ct);
            return evaluation;
        }

        public async Task<Evaluation> DeleteEvaluationByIdAsync(int id, CancellationToken ct = default)
        {
            var evaluation = await GetEvaluationByIdAsync(id, ct);
            if (evaluation == null)
            {
                throw new KeyNotFoundException($"Evaluation with ID {id} not found.");
            }
            _context.Evaluations.Remove(evaluation);
            await _context.SaveChangesAsync(ct);
            return evaluation;
        }
    }
}
