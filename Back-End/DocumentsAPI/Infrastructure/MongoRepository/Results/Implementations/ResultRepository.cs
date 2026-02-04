using Domain.Models;
using Infrastructure.DbSettings;
using Infrastructure.MongoRepository.Results.Interfaces;
using Infrastructure.PageSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.MongoRepository.Results.Implementations
{
    public class ResultRepository : IResultRepository
    {

        private readonly IMongoCollection<Result> _collection;

        public ResultRepository(IOptions<ResultsMongoDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Result>(
                settings.Value.CollectionName);
        }

        public async Task CreateAsync(Result newResult, CancellationToken token)
        {
            await _collection.InsertOneAsync(newResult, cancellationToken: token);
        }

        public async Task DeleteAsync(string id, CancellationToken token)
        {
            await _collection.DeleteOneAsync(r => r.Id == id, token);
        }

        public async Task<PaginatedResult<Result>> GetAllResult(PageInfo pageInfo, CancellationToken token)
        {
            var totalRecords = await _collection.CountDocumentsAsync(_ => true, cancellationToken: token);

            var results = await _collection
                .Find(_ => true)
                .Skip((pageInfo.Page - 1) * pageInfo.ItemsPerPage)
                .Limit(pageInfo.ItemsPerPage)
                .ToListAsync(token);

            return new PaginatedResult<Result>
                (
                results,
                pageInfo.Page,
                pageInfo.ItemsPerPage,
                totalRecords
                );
        }

        public async Task<Result?> GetByIdAsync(string id, CancellationToken token)
        {
            return await _collection
                .Find(r => r.Id == id)
                .FirstOrDefaultAsync(token);
        }

        public async Task UpdateResult(string id, Result updatedResult, CancellationToken token)
        {
            await _collection.ReplaceOneAsync(r => r.Id == id, updatedResult, cancellationToken: token);
        }
    }
}
