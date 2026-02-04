using Application.DTO;
using Application.DTO.Result;
using Domain.Models.PageModels;

namespace Application.Services.Interface
{
    public interface IOfficeService
    {
        Task<Result<IReadOnlyCollection<ReadOfficeDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Result<ReadOfficeDTO>> GetByIdAsync(string id, CancellationToken token);
        Task<Result<ReadOfficeDTO>> CreateAsync(CreateOfficeDTO newOffice, CancellationToken token);
        Task<Result<ReadOfficeDTO>> Update(string id, UpdateOfficeDTO updatedOffice, CancellationToken token);
        Task<Result> RemoveAsync(string id, CancellationToken token);
    }
}