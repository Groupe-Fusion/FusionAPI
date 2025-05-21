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

        [HttpGet("{evaluationId}")]
        [ActionName(nameof(GetEvaluationByIdAsync))]
        public async Task<IActionResult> GetEvaluationByIdAsync(int evaluationId, CancellationToken ct)
        {
            try
            {
                var evaluation = await _getEvaluationByIdUseCase.ExecuteAsync(evaluationId, ct);
                return evaluation != null ? Ok(evaluation) : NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEvaluationAsync([FromBody] Evaluation request, CancellationToken ct)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid evaluation data");
                }
                var evaluation = new Evaluation
                {
                    Rating = request.Rating,
                    Comment = request.Comment,
                    CreatedAt = request.CreatedAt,
                    UserId = request.UserId,
                    ReservationId = request.ReservationId,
                    UpdatedAt = request.UpdatedAt
                };
                var createdEvaluation = await _addEvaluationUseCase.ExecuteAsync(evaluation, ct);
                return CreatedAtAction(nameof(GetEvaluationByIdAsync), new { evaluationId = createdEvaluation.Id }, createdEvaluation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
