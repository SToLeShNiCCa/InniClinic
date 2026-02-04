using Domain.Models;
using Infrastructure.PageSettings;

namespace Infrastructure.MongoRepository.Results.Interfaces
{
    public interface IResultRepository
    {
        Task<PaginatedResult<Result>> GetAllResult(PageInfo pageInfo, CancellationToken token);
        Task<Result?> GetByIdAsync(string id, CancellationToken token);
        Task CreateAsync(Result newResult, CancellationToken token);
        Task DeleteAsync(string id, CancellationToken token);
        Task UpdateResult(string id, Result updatedResult, CancellationToken token);
    }
}
