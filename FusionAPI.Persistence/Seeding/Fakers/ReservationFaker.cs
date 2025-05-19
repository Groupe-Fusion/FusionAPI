using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
