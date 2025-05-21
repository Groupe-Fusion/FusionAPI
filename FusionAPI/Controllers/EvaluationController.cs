using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FusionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly IAddEvaluationUseCase _addEvaluationUseCase;
        private readonly IGetEvaluationByIdUseCase _getEvaluationByIdUseCase;
        private readonly IGetAllEvaluationsUseCase _getAllEvaluationsUseCase;
        private readonly IDeleteEvaluationByIdUseCase _deleteEvaluationByIdUseCase;
        public EvaluationController(
            IAddEvaluationUseCase addEvaluationUseCase,
            IGetEvaluationByIdUseCase getEvaluationByIdUseCase,
            IGetAllEvaluationsUseCase getAllEvaluationsUseCase,
            IDeleteEvaluationByIdUseCase deleteEvaluationByIdUseCase)
        {
            _addEvaluationUseCase = addEvaluationUseCase;
            _getEvaluationByIdUseCase = getEvaluationByIdUseCase;
            _getAllEvaluationsUseCase = getAllEvaluationsUseCase;
            _deleteEvaluationByIdUseCase = deleteEvaluationByIdUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluationsAsync(CancellationToken ct)
        {
            var evaluations = await _getAllEvaluationsUseCase.ExecuteAsync(ct);
            return Ok(evaluations);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluationAsync(int id, CancellationToken ct)
        {
            var evaluation = await _deleteEvaluationByIdUseCase.ExecuteAsync(id, ct);
            if (evaluation == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvaluationByIdAsync(int id, CancellationToken ct)
        {
            var evaluation = await _getEvaluationByIdUseCase.ExecuteAsync(id, ct);
            if (evaluation == null)
            {
                return NotFound();
            }
            return Ok(evaluation);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvaluationAsync([FromBody] Evaluation evaluation, CancellationToken ct)
        {
            if (evaluation == null)
            {
                return BadRequest("Evaluation cannot be null.");
            }
            var addedEvaluation = await _addEvaluationUseCase.ExecuteAsync(evaluation, ct);
            return CreatedAtAction(nameof(GetEvaluationByIdAsync), new { id = addedEvaluation.Id }, addedEvaluation);
        }
    }
}
