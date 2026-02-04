using Domain.Models;
using Domain.Models.PageModels;

namespace Infrastructure.Repository.Interface
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByIdAsync(int id, CancellationToken token);
        Task<PaginatedResult<Appointment>> GetAllAsync(PageInfo pageInfo, CancellationToken token);
        Task CreateAsync(Appointment appointment, CancellationToken token);
        void Delete(Appointment appointment);
        Task SaveChangesAsync(CancellationToken token);
    }
}
