using FusionAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Applicatif.Core
{
    public interface IAddEvaluationUseCase
    {
        Task<Evaluation> ExecuteAsync(Evaluation newEvaluation, CancellationToken cancellationToken);
    }
}
