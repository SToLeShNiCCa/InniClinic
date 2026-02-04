using Domain.Models;

namespace Infrastructure.MongoRepository.Documents.Interface
{
    public interface IDocumentRepository
    {
        Task<Document?> GetByResultIdAsync(string id, CancellationToken token);
        Task CreateAsync(Document document, CancellationToken token);
        Task DeleteAsync(string id, CancellationToken token);
    }
}
