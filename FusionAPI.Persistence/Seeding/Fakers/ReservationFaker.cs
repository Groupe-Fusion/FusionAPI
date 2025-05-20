using Bogus;
using FusionAPI.Domain.Models;

namespace FusionAPI.Persistence.Seeding.Fakers
{
    public sealed class ReservationFaker : Faker<Reservation>
    {
        public enum Dimension
        {
            Petit,
            Moyen,
            Large
        }

        public enum Category
        {
            Livraison,
            Déménagement,
            Transport,
            Autre
        }

        public enum ReservationStatus
        {
            EnAttente,
            EnCours,
            Terminé,
            Annulé
        }

        public ReservationFaker()
        {
            //RuleFor(r => r.ReservationId, f => f.UniqueIndex);  
            RuleFor(r => r.Name, f => f.Commerce.ProductName());
            RuleFor(r => r.Description, f => f.Lorem.Sentence());
            RuleFor(r => r.UserId, 1);
            RuleFor(r => r.User, f => new UserFaker().Generate());
            RuleFor(r => r.CreatedByName, f => f.Person.FullName);
            RuleFor(r => r.StartLocation, f => f.Address.City());
            RuleFor(r => r.EndLocation, f => f.Address.City());
            RuleFor(r => r.Dimension, f => f.PickRandom<Dimension>().ToString());
            RuleFor(r => r.Weight, f => f.Random.Int(1, 100));
            RuleFor(r => r.IsNow, f => f.Random.Bool());
            RuleFor(r => r.DeliveryDate, f => f.Date.Future(1));
            RuleFor(r => r.Category, f => f.PickRandom<Category>().ToString());
            RuleFor(r => r.Rating, f => f.Random.Int(1, 5));
            RuleFor(r => r.Price, f => f.Random.Double(10, 1000));
            RuleFor(r => r.InHour, f => f.Random.Double(1, 24));
            RuleFor(r => r.RecipientName, f => f.Person.FullName);
            RuleFor(r => r.RecipientPhone, f => f.Person.Phone);
            RuleFor(r => r.RecipientAddress, f => f.Address.FullAddress());
            RuleFor(r => r.RecipientCity, f => f.Address.City());
            RuleFor(r => r.RecipientPostalCode, f => f.Address.ZipCode());
            RuleFor(r => r.PackageType, f => f.PickRandom<Dimension>().ToString());
            RuleFor(r => r.isFragile, f => f.Random.Bool());
            RuleFor(r => r.ReservationStatus, f => f.PickRandom<ReservationStatus>().ToString());
        }
    }
}
