using Application.DTO.Doctors;
using Application.DTO.Result;
using Domain.DBServices.Models.PaginationModel;

namespace Application.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Result<IReadOnlyCollection<ReadDoctorDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Result<ReadDoctorDTO>> GetByIdAsync(int id, CancellationToken token);
        Task<Result<ReadDoctorDTO>> CreateAsync(CreateDoctorDTO doctor, CancellationToken token);
        Task <Result<ReadDoctorDTO>> UpdateAsync(int id, UpdateDoctorDTO doctor,CancellationToken token);
        Task <Result> DeleteAsync(int id,CancellationToken token);
    }
}
