using FusionAPI.Domain.Models;

namespace FusionAPI.Domain.Repositories.Core
{
    public interface ILocalisationRepository
    {
        Task<List<Localisation>> GetAllLocalisationsAsync(CancellationToken ct = default);
        Task<Localisation> GetLocalisationByIdAsync(string id, CancellationToken ct = default);
        Task<Localisation> AddLocalisationAsync(Localisation localisation, CancellationToken ct = default);
        Task<Localisation> UpdateLocalisationAsync(string id, Localisation localisation, CancellationToken ct = default);
        Task<Localisation> DeleteLocalisationAsync(string id, CancellationToken ct = default);
    }
}
