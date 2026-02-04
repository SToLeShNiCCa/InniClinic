using Application.DTO.Result;
using Application.DTO.ServiceCategoryDTO;
using Domain.Models.PageModels;

namespace Application.Services.Interfaces
{
    public interface IServiceCategoryServices
    {
        Task<Result<IReadOnlyCollection<ReadServiceCategoryDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Result<ReadServiceCategoryDTO>> GetByIdAsync(int id, CancellationToken token);
        Task<Result<ReadServiceCategoryDTO>> CreateAsync(CreateServiceCategoryDTO serviceDTO, CancellationToken token);
        Task<Result<ReadServiceCategoryDTO>> UpdateAsync(int id, UpdateServiceCategoryDTO serviceDTO, CancellationToken token);
        Task<Result> DeleteAsync(int id, CancellationToken token);
    }
}
