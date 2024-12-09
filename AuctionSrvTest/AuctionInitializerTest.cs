using AuctionService.Data;
using AuctionService.Data.DbInitializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionSrvTest;

public class AuctionInitializerTest
{
    private AuctionDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AuctionDbContext>()
            .UseInMemoryDatabase(databaseName: "TestAuctionDb")
            .Options;
        return new AuctionDbContext(options);
    }
    [Fact]
    public void SeedData_ShouldAddAuctions_WhenDatabaseIsEmpty()
    {
        //Arrange
        var services = new ServiceCollection();
        services.AddDbContext<AuctionDbContext>(options => options.UseInMemoryDatabase("AuctionTestDb"));
        var serviceProvider = services.BuildServiceProvider();
        //ACT

        using(var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AuctionDbContext>();
            DbInitializer.SeedData(context);

            Assert.Equal(10, context.Auctions.Count());

            var auction = context.Auctions.SingleOrDefault(x => x.Id ==Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"));
            Assert.NotNull(auction);
            Assert.Equal("Ford", auction.Item.Make);
            Assert.Equal("GT", auction.Item.Model);
        }

    }
}