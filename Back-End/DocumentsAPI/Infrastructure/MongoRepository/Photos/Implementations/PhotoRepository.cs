using Domain.Models;
using Infrastructure.MongoRepository.Photos.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.MongoRepository.Photos.Implementations
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IMongoCollection<Photo> _collection;
        public PhotoRepository(IOptions<DbSettings.PhotosMongoDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Photo>(
                settings.Value.CollectionName);
        }
        public async Task CreateAsync(Photo photo, CancellationToken token)
        {
            await _collection.InsertOneAsync(photo, cancellationToken: token);
        }

        public async Task DeleteAsync(string id, CancellationToken token)
        {
            await _collection.DeleteOneAsync(p => p.Id == id, token);
        }

        public async Task<Photo?> GetByIdAsync(string id, CancellationToken token)
        {
            return await _collection.Find(photo => photo.Id == id).FirstOrDefaultAsync(token);
        }
    }
}
