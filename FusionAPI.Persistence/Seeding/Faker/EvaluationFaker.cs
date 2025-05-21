using Bogus;
using FusionAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Persistence.Seeding.Faker
{
    public sealed class EvaluationFaker : Faker<Evaluation>
    {
        public EvaluationFaker()
        {
            RuleFor(e => e.Rating, f => f.Random.Int(1, 5));
            RuleFor(e => e.Comment, f => f.Lorem.Sentence(10));
            RuleFor(e => e.CreatedAt, f => f.Date.Past(1));
            RuleFor(e => e.UpdatedAt, f => f.Date.Recent(1));
            RuleFor(e => e.UserId, f => f.Random.Int(1, 100));
            RuleFor(e => e.ReservationId, f => f.Random.Int(1, 100));
        }
    }
}
