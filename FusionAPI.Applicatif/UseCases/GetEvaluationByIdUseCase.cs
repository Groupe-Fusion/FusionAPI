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
    public class GetEvaluationByIdUseCase : IGetEvaluationByIdUseCase
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public GetEvaluationByIdUseCase(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<Evaluation?> ExecuteAsync(int evaluationId, CancellationToken ct = default)
        {
            var evaluation = await _evaluationRepository.GetEvaluationByIdAsync(evaluationId, ct);
            if (evaluation == null)
            {
                throw new KeyNotFoundException($"Evaluation with ID {evaluationId} not found.");
            }
            return evaluation;
        }
    }
}
