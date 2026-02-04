using Application.DTO.Result;
using Application.DTO.ServiceDTO;
using Domain.Models.PageModels;

namespace Application.Services.Interfaces
{
    public interface IServiceServices
    {
        Task<Result<IReadOnlyCollection<ReadServiceDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Result<ReadServiceDTO>> GetByIdAsync(int id, CancellationToken token);
        Task<Result<ReadServiceDTO>> CreateAsync(CreateServiceDTO serviceDTO, CancellationToken token);
        Task<Result<ReadServiceDTO>> UpdateAsync(int id, UpdateServiceDTO serviceDTO, CancellationToken token);
        Task<Result> DeleteAsync(int id, CancellationToken token);
    }
}
