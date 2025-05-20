using FusionAPI.Domain.Models;
using FusionAPI.Persistence.Seeding.Fakers;

namespace FusionAPI.Persistence.Seeding
{
    public static partial class SeedingHelper
    {
        public static void GenerateFakePaymentData(this PaymentManagerContext context)
        {
            const int NUMBER_OF_PAYMENTS = 10;
            Console.WriteLine("Seeding");
            if (!context.Payments.Any())
            {
                List<Payment> fakePayments = new PaymentFaker().Generate(NUMBER_OF_PAYMENTS);
                context.Payments.AddRange(fakePayments);
                context.SaveChanges();
                Console.WriteLine($"Generated {NUMBER_OF_PAYMENTS} fake payments");
            }
            else
            {
                Console.WriteLine("Database already seeded with fake data");
            }
        }
    }
}