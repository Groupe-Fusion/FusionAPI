using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Persistence.Seeding
{
    public class DbSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Initializing database");

            try
            {
                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                using EvaluationManagerContext context = new EvaluationManagerContext(scopedServices.GetRequiredService<DbContextOptions<EvaluationManagerContext>>());
                Seed(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Seed(EvaluationManagerContext context)
        {
            Console.WriteLine("trying to seed");
            if (context == null)
            {
                return;
            }

            if (!context.Database.IsInMemory())
            {
                Console.WriteLine("Using local database");
            }
            else
            {
                Console.WriteLine("Using in-memory database");
            }

            context.GenerateFakeEvaluationData();
            Console.WriteLine("Seeded");
        }
    }

    public static class DatabaseFacadeExtensions
    {
        public static bool IsInMemory(this DatabaseFacade databaseFacade)
        {
            return databaseFacade.ProviderName == "Microsoft.EntityFrameworkCore.InMemory";
        }
    }
}
