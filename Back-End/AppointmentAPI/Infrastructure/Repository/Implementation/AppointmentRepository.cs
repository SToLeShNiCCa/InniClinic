using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.DBSettings.DBContext;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentDbContext _context;

        public AppointmentRepository(AppointmentDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Appointment appointment, CancellationToken token)
        {
            await _context.Appointments.AddAsync(appointment, token);
        }

        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }

        public async Task<PaginatedResult<Appointment>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var query = _context.Appointments
                .AsNoTracking()
                .AsQueryable();

            var totalRecords = await _context.Appointments.CountAsync(token);

            var appointments = await query
                .Skip((pageInfo.Page - 1) * pageInfo.ItemsPerPage)
                .Take(pageInfo.ItemsPerPage)
                .ToListAsync(token);

            return new PaginatedResult<Appointment>
                (
                    appointments,
                    pageInfo.Page,
                    pageInfo.ItemsPerPage,
                    totalRecords
                );
        }

        public async Task<Appointment?> GetByIdAsync(int id, CancellationToken token)
        {
            return await _context.Appointments.FindAsync(id, token);
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}
