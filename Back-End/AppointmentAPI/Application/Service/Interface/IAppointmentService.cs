using Application.DTO;
using Application.DTO.Result;
using Domain.Models.PageModels;

namespace Application.Service.Interface
{
    public interface IAppointmentService
    {
        Task<Result<IReadOnlyCollection<ReadAppointmentDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Result<ReadAppointmentDTO>> GetByIdAsync(int id, CancellationToken token);
        Task<Result<ReadAppointmentDTO>> CreateAsync(CreateAppointmentDTO dto, CancellationToken token);
        Task<Result<ReadAppointmentDTO>> UpdateAsync (int id, UpdateAppointmentDTO dto, CancellationToken token);
        Task<Result> DeleteAsync(int id, CancellationToken token);
    }
}
