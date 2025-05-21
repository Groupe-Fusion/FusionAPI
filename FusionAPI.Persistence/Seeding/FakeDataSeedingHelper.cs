using FusionAPI.Domain.Models;
using FusionAPI.Persistence.Seeding.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Persistence.Seeding
{
    public static partial class FakeDataSeedingHelper
    {
        public static void GenerateFakeEvaluationData(this EvaluationManagerContext context)
        {
            const int NUMBER_OF_EvaluationS = 10;
            Console.WriteLine("Seeding");
            if (!context.Evaluations.Any())
            {
                List<Evaluation> fakeEvaluations = new EvaluationFaker().Generate(NUMBER_OF_EvaluationS);
                context.Evaluations.AddRange(fakeEvaluations);
                context.SaveChanges();
                Console.WriteLine($"Generated {NUMBER_OF_EvaluationS} fake Evaluations");
            }
            else
            {
                Console.WriteLine("Database already seeded with fake data");
            }
        }
    }
}
