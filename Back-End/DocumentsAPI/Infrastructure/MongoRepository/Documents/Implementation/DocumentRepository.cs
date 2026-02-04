using Domain.Models;
using Infrastructure.MongoRepository.Documents.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.MongoRepository.Documents.Implementation
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IMongoCollection<Document> _collection;

        public DocumentRepository(IOptions<DbSettings.DocumentsMongoDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Document>(
                settings.Value.CollectionName);
        }

        public async Task CreateAsync(Document document, CancellationToken token)
        {
            await _collection.InsertOneAsync(document, cancellationToken: token);
        }

        public async Task DeleteAsync(string id, CancellationToken token)
        {
            await _collection.DeleteOneAsync(d => d.Id == id, token);
        }

        public async Task<Document?> GetByResultIdAsync(string resultId, CancellationToken token)
        {
            return await _collection.Find(p => p.ResultId == resultId).FirstOrDefaultAsync(token);
        }
    }
}
