using FusionAPI.Domain.Models;

namespace FusionAPI.Applicatif.Core
{
    public interface IAddLocalisationUseCase
    {
        Task<Localisation> AddLocalisationAsync(Localisation localisation, CancellationToken ct = default);
    }
}
