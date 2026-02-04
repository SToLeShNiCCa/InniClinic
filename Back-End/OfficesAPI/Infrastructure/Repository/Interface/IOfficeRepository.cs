using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interface
{
    public interface IOfficeRepository
    {
        Task<PaginatedResult<Office>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Office?> GetByIdAsync(string id, CancellationToken token);
        Task CreateAsync(Office newOffice, CancellationToken token);
        Task Update(string id, Office updatedOffice, CancellationToken token);
        Task RemoveAsync(string id, CancellationToken token);
    }
}
