using ShortURL.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ShortURL.Services
{
    public class UrlsDbService
    {
        private readonly IMongoCollection<TinyUrlUser> _usersCollection;

        public UrlsDbService(IOptions<UrlsDatabaseSettings> urlsDatabaseSettings)
        {
        var mongoClient = new MongoClient(
            urlsDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            urlsDatabaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<TinyUrlUser>(
            urlsDatabaseSettings.Value.UrlsCollectionName);
        }

        public async Task<List<TinyUrlUser>> GetAsync() =>
            await _usersCollection.Find(_ => true).ToListAsync();

        public async Task<TinyUrlUser> GetAsync(string shortUrl) =>
            await _usersCollection.Find(x => x.shortUrl == shortUrl).FirstOrDefaultAsync();

        public async Task CreateAsync(TinyUrlUser newUser) =>
            await _usersCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, TinyUrlUser updatedUser) =>
            await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task RemoveAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
    }
}
