using Microsoft.EntityFrameworkCore;


namespace Neri_SportsStore.Models
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			StoreDbContext context = app.ApplicationServices
				.CreateScope().ServiceProvider
				.GetRequiredService<StoreDbContext>();

			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
			if (!context.Products.Any())
			{
				context.Products.AddRange(
				new Product
				{
					Name = "Kayak",
					Description = "A boat for one person",
					Category = "Watersports",
					Price = 275
				},
				new Product
				{
					Name = "Kayak",
					Description = "A boat for one person",
					Category = "Ball Sports",
					Price = 275
				},
				new Product
				{
					Name = "Kayak",
					Description = "A boat for one person",
					Category = "Badminton",
					Price = 275
				},
				new Product
				{
					Name = "Kayak",
					Description = "A boat for one person",
					Category = "Soccer",
					Price = 275
				}
				);
				context.SaveChanges();
			}
		}

	}
}
