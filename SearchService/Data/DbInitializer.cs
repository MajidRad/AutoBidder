using MongoDB.Driver;
using SearchService.Models;
using SearchService.Services;
using System.Text.Json;

namespace SearchService.Data;

public class DbInitializer
{
    private readonly SearchSvc _searchSvc;

    public DbInitializer(SearchSvc searchSvc)
    {
        _searchSvc = searchSvc;
    }
    public static async Task InitDb(WebApplication app)
    {

        //await DB.InitAsync("Search", MongoClientSettings
        //.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        //await DB.Index<Item>()
        //    .Key(x => x.Make, KeyType.Text)
        //    .Key(x => x.Model, KeyType.Text)
        //    .Key(x => x.Color, KeyType.Text)
        //    .CreateAsync();
        //var count = await DB.CountAsync<Item>();
        //using var scope = app.Services.CreateScope();
        //var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();
        //var items = await httpClient.GetItemForSearchDb();
        //Console.WriteLine(items.Count+"returned from auction service ");
        //if (items.Count > 0) await DB.SaveAsync(items);
    }
}
