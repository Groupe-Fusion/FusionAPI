using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FusionAPI.Domain.Models
{
    public class Localisation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? LocalisationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTimeOffset DateEnregistrement { get; set; } = DateTimeOffset.UtcNow;
    }
}
