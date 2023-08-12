namespace Tehnoforest.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;
    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.Automower;
    using static DataBaseSeeder;

    public class ServiceTests
    {
        private DbContextOptions<TehnoforestDbContext> dbOptions;
        private TehnoforestDbContext dbContext;

        private IAutomowerService automowerService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TehnoforestDbContext>()
                .UseInMemoryDatabase("TehnoforestInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new TehnoforestDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.automowerService = new AutomowerService(this.dbContext);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AutomowerExistsByIdShouldReturnTrueWhenExists()
        {
            int automowerId = DataBaseSeeder.Product.Id;

            bool result = await this.automowerService.ExistsByIdAsync(automowerId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistByModelAsyncShouldReturnTrueWhenExists()
        {
            string automowerModel = DataBaseSeeder.Product.Model;

            bool result = await this.automowerService.ExistByModelAsync(automowerModel);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteAutomowerByIdAsyncShouldReturnTrueWhenExists()
        {
            int automowerId = DataBaseSeeder.Product.Id;

            await this.automowerService.DeleteAutomowerByIdAsync(automowerId);

            Assert.IsFalse(DataBaseSeeder.Product.IsAvailable);

        }

        [Test]
        public async Task CreateAndReturnIdAsync()
        {
            Product newAutomower = new Product()
            {
                Model = "405",
                Description = "xhgifs rkhasgf yjsajz yfgajs",
                ImageUrl = "img.url",
                Price = 2300,
                Availability = 2
            };

            await this.dbContext.Products.AddAsync(newAutomower);
            await this.dbContext.SaveChangesAsync();

            Assert.That(newAutomower.Id, Is.EqualTo(2));
        }

        [Test]
        public async Task GetDetailsByIdAsyncShouldRetturnCorrectProductData()
        {
            int automowerId = DataBaseSeeder.Product.Id;

            var result = await automowerService.GetDetailsByIdAsync(automowerId);

            Assert.IsNotNull(result);

            var productInDb = dbContext.Products.Find(automowerId);

            Assert.That(result.Id, Is.EqualTo(productInDb.Id));
            Assert.That(result.Model, Is.EqualTo(productInDb.Model));
        }

        [Test]
        public async Task EditShouldEditProductCorrectly()
        {
            var product = new Product
            {
                Model = "New Model",
                Description = "sj gfs fs fs gfsg s gs",
                ImageUrl = "img.url",
                Price = 3000,
                Availability = 2
            };

            await this.dbContext.AddAsync(product);
            await this.dbContext.SaveChangesAsync();

            AutomowerFormModel formModel = new AutomowerFormModel();
            formModel.Model = "New Model Automower";
            formModel.Description = "sj gfs fs fs gfsg s gs";
            formModel.ImageUrl = "img.url";
            formModel.Price = 3000;
            formModel.Availability = 2;

            await automowerService.EditAutomowerByIdAndFormModelAsync(product.Id, formModel);

            var newProductInDb = await this.dbContext.Products.FindAsync(product.Id);
            Assert.IsNotNull(newProductInDb);
            //Assert.That(newProductInDb.Model, Is.EqualTo(product.Model));   
        }
    }
}