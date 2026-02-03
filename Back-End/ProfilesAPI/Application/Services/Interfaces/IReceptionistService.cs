using Application.DTO.Receptionist;
using Application.DTO.Result;
using Domain.DBServices.Models.PaginationModel;

namespace Application.Services.Interfaces
{
    public interface IReceptionistService
    {
        Task<Result<IReadOnlyCollection<ReadReceptionistDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Result<ReadReceptionistDTO>> GetByIdAsync(int id, CancellationToken token);
        Task<Result<ReadReceptionistDTO>> CreateAsync(CreateReceptionistDTO receptionist, CancellationToken token);
        Task<Result<ReadReceptionistDTO>> UpdateAsync(int id, UpdateReceptionistDTO receptionist, CancellationToken token);
        Task<Result> DeleteAsync(int id, CancellationToken token);
    }
}
