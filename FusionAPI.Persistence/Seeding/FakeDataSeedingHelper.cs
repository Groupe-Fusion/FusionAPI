using FusionAPI.Domain.Models;
using FusionAPI.Persistence.Seeding.Fakers;

namespace FusionAPI.Persistence.Seeding
{
    public static partial class SeedingHelper
    {
        public static void GenerateFakeUserData(this UserManagerContext context)
        {
            const int NUMBER_OF_USERS = 10;
            Console.WriteLine("Seeding");
            if (!context.Users.Any())
            {
                List<User> fakeUsers = new UserFaker().Generate(NUMBER_OF_USERS);
                context.Users.AddRange(fakeUsers);
                context.SaveChanges();
                Console.WriteLine($"Generated {NUMBER_OF_USERS} fake users");
            }
        }
    }
}
