using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Applicatif.UseCases
{
    public class GetAllEvaluationsUseCase : IGetAllEvaluationsUseCase
    {
        private readonly IEvaluationRepository _evaluationRepository;
        public GetAllEvaluationsUseCase(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }
        public async Task<IList<Evaluation>> ExecuteAsync(CancellationToken ct = default)
        {
            var evaluations = await _evaluationRepository.GetAllEvaluationsAsync(ct);
            return evaluations;
        }
    }
}
