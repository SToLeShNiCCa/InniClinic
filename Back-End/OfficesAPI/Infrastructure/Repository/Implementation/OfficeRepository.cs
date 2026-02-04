using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.DBSettings;
using Infrastructure.Repository.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Infrastructure.Repository.Implementation
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IMongoCollection<Office> _officeCollection;

        public OfficeRepository(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _officeCollection = mongoDatabase.GetCollection<Office>(
                settings.Value.OfficesCollectionName);
        }
        public async Task CreateAsync(Office newOffice, CancellationToken token)
        {
            await _officeCollection.InsertOneAsync(newOffice);
        }

        public async Task<PaginatedResult<Office>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var totalRecords = await _officeCollection.CountDocumentsAsync(_ => true);

            var offices = await _officeCollection
                .Find(_ => true)
                .Skip((pageInfo.Page - 1)* pageInfo.ItemsPerPage)
                .Limit(pageInfo.ItemsPerPage)
                .ToListAsync(token);

            return new PaginatedResult<Office>
                (
                offices,
                pageInfo.Page,
                pageInfo.ItemsPerPage,
                totalRecords
                );
        }

        public async Task<Office?> GetByIdAsync(string id, CancellationToken token)
        {
            return await _officeCollection.Find(p => p.Id == id).FirstOrDefaultAsync(token);
        }

        public async Task RemoveAsync(string id, CancellationToken token)
        {
            await _officeCollection.DeleteOneAsync(p => p.Id == id, token);
        }

        public async Task Update(string id, Office updatedOffice, CancellationToken token)
        {
            await _officeCollection.ReplaceOneAsync(p => p.Id == id, updatedOffice);
        }
    }
}
