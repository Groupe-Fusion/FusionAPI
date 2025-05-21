using FusionAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Domain.Repositories.Core
{
    public interface IEvaluationRepository
    {
        Task<IList<Evaluation>> GetAllEvaluationsAsync(CancellationToken ct = default);
        Task<Evaluation?> GetEvaluationByIdAsync(int id, CancellationToken ct = default);
        Task<Evaluation> AddEvaluationAsync(Evaluation user, CancellationToken ct = default);
        Task<Evaluation> DeleteEvaluationByIdAsync(int id, CancellationToken ct = default);
    }
}
