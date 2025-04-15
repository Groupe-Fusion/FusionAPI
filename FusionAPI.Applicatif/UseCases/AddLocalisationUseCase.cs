using FusionAPI.Applicatif.Core;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;

namespace FusionAPI.Applicatif.UseCases
{
    public class AddLocalisationUseCase : IAddLocalisationUseCase
    {
        /*private readonly ILocalisationRepository _localisationRepository;
        public AddLocalisationUseCase(ILocalisationRepository localisationRepository)
        {
            _localisationRepository = localisationRepository;
        }


        public async Task<Localisation> AddLocalisationAsync(Localisation localisation, CancellationToken ct = default)
        {
            await _localisationsCollection.InsertOneAsync(localisation, null, ct);
            return localisation;
        }*/
        public Task<Localisation> AddLocalisationAsync(Localisation localisation, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
