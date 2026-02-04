using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IServiceCategoryRepository
    {
        Task<PaginatedResult<ServiceCategory>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<ServiceCategory?> GetByIdAsync(int id, CancellationToken token);
        Task CreateAsync(ServiceCategory serviceCategory, CancellationToken token);
        void Delete(ServiceCategory serviceCategory);
        Task SaveDataAsync(CancellationToken token);
    }
}
