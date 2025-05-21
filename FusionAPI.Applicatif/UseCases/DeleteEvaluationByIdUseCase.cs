using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;

namespace FusionAPI.Applicatif.UseCases
{
    public class DeleteEvaluationByIdUseCase : IDeleteEvaluationByIdUseCase
    {
        private readonly IEvaluationRepository _evaluationRepository;
        public DeleteEvaluationByIdUseCase(IEvaluationRepository evaluationRepository)
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
            await _evaluationRepository.DeleteEvaluationByIdAsync(evaluationId, ct);
            return evaluation;
        }
    }
}
