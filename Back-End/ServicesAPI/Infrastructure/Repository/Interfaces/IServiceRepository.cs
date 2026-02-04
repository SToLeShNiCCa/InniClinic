using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IServiceRepository
    {
        Task<PaginatedResult<Service>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Service?> GetByIdAsync(int id, CancellationToken token);
        Task CreateAsync(Service service, CancellationToken token);
        void Delete(Service service);
        Task SaveDataAsync(CancellationToken token);
    }
}
