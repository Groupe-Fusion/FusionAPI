using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FusionAPI.Persistence.Seeding.Fakers
{
    class DbSeeder
	{
        public static void Initialize(IServiceProvider serviceProvider)
		{
			Console.WriteLine("Initializing database");

			try
			{
				using var scope = serviceProvider.CreateScope();
				var scopedServices = scope.ServiceProvider;
				using PaymentManagerContext context = new PaymentManagerContext(scopedServices.GetRequiredService<DbContextOptions<PaymentManagerContext>>());
				Seed(context);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private static void Seed(PaymentManagerContext context)
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

			context.GenerateFakePaymentData();
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
