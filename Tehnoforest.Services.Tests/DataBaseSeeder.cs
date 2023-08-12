namespace Tehnoforest.Services.Tests
{
    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;

    public static class DataBaseSeeder
    {
        public static Product Product;

        public static void SeedDatabase(TehnoforestDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            Product = new Product()
            {
                Model = "305",
                Description = "Comfortable automower which cuth the grass in your garden.",
                ImageUrl = "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/robotic-mowers/photos/studio/du-849284.webp?v=450289ff148fd9b9&format=WEBP_LANDSCAPE_CONTAIN_XXL",
                Price = 2500,
                Availability = 1,
                IsAvailable = true
            };

            dbContext.Products.Add(Product);
            dbContext.SaveChanges();
        }
    }
}
