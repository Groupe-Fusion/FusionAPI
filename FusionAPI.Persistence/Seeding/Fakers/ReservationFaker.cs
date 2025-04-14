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
        public ReservationFaker()
        {
            //RuleFor(r => r.ReservationId, f => f.UniqueIndex);
            RuleFor(r => r.Name, f => f.Commerce.ProductName());
            RuleFor(r => r.Description, f => f.Lorem.Sentence());
            RuleFor(r => r.CreatedBy, f => new UserFaker().Generate());
            RuleFor(r => r.CreatedByName, f => f.Person.FullName);
        }
    }
}
