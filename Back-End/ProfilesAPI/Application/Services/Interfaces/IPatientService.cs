using Application.DTO.Patients;
using Application.DTO.Result;
using Domain.DBServices.Models.PaginationModel;

namespace Application.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Result<IReadOnlyCollection<ReadPatientDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task<Result<ReadPatientDTO>> GetByIdAsync(int id, CancellationToken token);
        Task<Result<ReadPatientDTO>> CreateAsync(CreatePatientDTO patient, CancellationToken token);
        Task<Result<ReadPatientDTO>> UpdateAsync(int id, UpdatePatientDTO patient, CancellationToken token);
        Task<Result> DeleteAsync(int id, CancellationToken token);
    }
}
