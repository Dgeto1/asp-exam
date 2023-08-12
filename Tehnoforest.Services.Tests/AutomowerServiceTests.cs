namespace Tehnoforest.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;

    public class AutomowerServiceTests
    {
        private DbContextOptions<TehnoforestDbContext> dbOptions;
        private TehnoforestDbContext dbContext;
        private Mock<TehnoforestDbContext> dbMock;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TehnoforestDbContext>()
                .UseInMemoryDatabase("TehnoforestInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new TehnoforestDbContext(this.dbOptions);

           /* this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.agentService = new AgentService(this.dbContext);*/
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AutomowerExistsByIdShouldReturnTrueWhenExists()
        {
            this.dbMock = new Mock<TehnoforestDbContext>()
                .Setup(db => db.Products)
                .Returns(new List<Product>()
                {

                });
        }
    }
}