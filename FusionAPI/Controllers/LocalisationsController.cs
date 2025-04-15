using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using Microsoft.AspNetCore.Mvc;

namespace FusionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalisationsController : ControllerBase
    {
        private readonly ILocalisationRepository _localisationRepository;

        public LocalisationsController(ILocalisationRepository localisationRepository)
        {
            _localisationRepository = localisationRepository;
        }

        [HttpGet]
        public async Task<List<Localisation>> GetAllLocalisations(CancellationToken ct = default)
        {
             return await _localisationRepository.GetAllLocalisationsAsync(ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Localisation>> GetLocalisationById(string id, CancellationToken ct = default)
        {
            var localisation = await _localisationRepository.GetLocalisationByIdAsync(id, ct);
            if (localisation == null)
            {
                return NotFound();
            }
            return localisation;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocalisation([FromBody] Localisation localisation, CancellationToken ct = default)
        {
            var addedLocalisation = await _localisationRepository.AddLocalisationAsync(localisation, ct);
            return CreatedAtAction(nameof(GetLocalisationById), new { id = addedLocalisation.LocalisationId }, addedLocalisation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocalisation(string id, [FromBody] Localisation updatedLocalisation, CancellationToken ct = default)
        {
            var localisation = await _localisationRepository.GetLocalisationByIdAsync(id, ct);

            if (localisation == null)
            {
                return NotFound();
            }

            updatedLocalisation.LocalisationId = localisation.LocalisationId;

            await _localisationRepository.UpdateLocalisationAsync(id, updatedLocalisation, ct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalisation(string id, CancellationToken ct = default)
        {
            var localisation = await _localisationRepository.GetLocalisationByIdAsync(id, ct);
            if (localisation == null)
            {
                return NotFound();
            }
            await _localisationRepository.DeleteLocalisationAsync(id, ct);
            return NoContent();
        }
    }
}
