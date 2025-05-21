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
    public class AddEvaluationUseCase : IAddEvaluationUseCase
    {
        private readonly IEvaluationRepository _evaluationRepository;
        public AddEvaluationUseCase(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<Evaluation> ExecuteAsync(Evaluation newEvaluation, CancellationToken cancellationToken)
        {
            if (newEvaluation == null)
            {
                throw new ArgumentNullException(nameof(newEvaluation), "New evaluation cannot be null.");
            }
            var createdEvaluation = await _evaluationRepository.AddEvaluationAsync(newEvaluation, cancellationToken);
            return createdEvaluation;
        }
    }
}
