using FusionAPI.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FusionAPI.Persistence.Repositories
{
    public class LocalisationRepository
    {
        private readonly IMongoCollection<Localisation> _localisationsCollection;

        public LocalisationRepository(IOptions<LocalisationDatabaseSettings> localisationDatabaseSettings)
        {
            var mongoClient = new MongoClient(localisationDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(localisationDatabaseSettings.Value.DatabaseName);
            _localisationsCollection = mongoDatabase.GetCollection<Localisation>(localisationDatabaseSettings.Value.LocalisationCollectionName);
        }

        public async Task<List<Localisation>> GetAllLocalisationsAsync(CancellationToken ct = default)
        {
            return await _localisationsCollection.Find(_ => true).ToListAsync(ct);
        }

        public async Task<Localisation> GetLocalisationByIdAsync(string id, CancellationToken ct = default)
        {
            return await _localisationsCollection.Find(x => x.LocalisationId == id).FirstOrDefaultAsync(ct);
        }

        public async Task<Localisation> AddLocalisationAsync(Localisation localisation, CancellationToken ct = default)
        {
            await _localisationsCollection.InsertOneAsync(localisation, null, ct);
            return localisation;
        }

        public async Task<Localisation> UpdateLocalisationAsync(string id, Localisation localisation, CancellationToken ct = default)
        {
            var result = await _localisationsCollection.ReplaceOneAsync(x => x.LocalisationId == id, localisation);
            if (result.IsAcknowledged && result.ModifiedCount > 0)
            {
                return localisation;
            }
            throw new Exception("Failed to update the localisation.");
        }

        public async Task<bool> DeleteLocalisationAsync(string id, CancellationToken ct = default)
        {
            var result = await _localisationsCollection.DeleteOneAsync(x => x.LocalisationId == id, ct);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
