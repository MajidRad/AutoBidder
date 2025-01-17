using Contracts.ExtensionMethods;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SearchService.Data;
using SearchService.Models;

namespace SearchService.Services;

public class SearchSvc
{
    private readonly IMongoCollection<Item> _mongoCollection;
    public SearchSvc(IOptions<MongoDbSettings> mongoSettings)
    {
        var mongoClient = new MongoClient(mongoSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);
        _mongoCollection = mongoDatabase.GetCollection<Item>(mongoSettings.Value.CollectionName);
    }
    public async Task<List<Item>> SearchItemsAsync(string? searchTerm = null)
    {
        var query = Builders<Item>.Filter.Empty;
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = Builders<Item>.Filter.Text(searchTerm);
        }
        var sortOption = Builders<Item>.Sort.Ascending(item => item.Make);
        if (!string.IsNullOrEmpty(searchTerm))
        {
            sortOption = Builders<Item>.Sort.MetaTextScore("textScore").Ascending(item => item.Make);
        }

        var result = await _mongoCollection.Find(query).Sort(sortOption).ToListAsync();
        return result;
    }
    public async Task<Item> GetItem(string Id)
    {
        var result = await _mongoCollection.AsQueryable().Where(x => x.Id == Id).FirstOrDefaultAsync();
        return result;
    }
    public async Task InsertItem(Item item)
    {
        await _mongoCollection.InsertOneAsync(item);
    }
    public async Task UpdateItem(string ID, Item updatedItem)
    {
        var filter = Builders<Item>.Filter.Eq(x => x.Id, ID);
        var result = await _mongoCollection.ReplaceOneAsync(filter, updatedItem);
        if (result.ModifiedCount == 0)
        {
            throw new Exception("no document found or updated");
        }
    }
    public async Task RemoveItem(string Id)
    {
        var filter = Builders<Item>.Filter.Eq(r => r.Id, Id);
        var result = await _mongoCollection.DeleteOneAsync(filter);
        if (result.DeletedCount == 0)
        {
            throw new Exception("no document found or deleted");
            ConsoleEx.ErrorMessage("no document found or deleted");
        }
    }
}
