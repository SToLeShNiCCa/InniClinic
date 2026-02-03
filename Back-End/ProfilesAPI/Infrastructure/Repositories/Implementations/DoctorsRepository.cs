using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Infrastructure.DbConfigurations.Contexts;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly ProfilesContext _context;

        public DoctorsRepository(ProfilesContext context)
        {
            _context = context;
        }
        public async Task SaveDataAsync(CancellationToken token) 
        {
            await _context.SaveChangesAsync(token);
        }
        public async Task CreateAsync(Doctor doctor, CancellationToken token)
        {
            await _context.Doctors.AddAsync(doctor, token);
        }

        public void Delete(Doctor doctor)
        {
            _context.Remove(doctor);
        }

        public async Task<PaginatedResult<Doctor>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var query = _context.Doctors
                .AsQueryable()
                .AsNoTracking();

            var totalRecords = await _context.Doctors.CountAsync(token);

            var doctors = await query
                .Skip((pageInfo.Page - 1) * pageInfo.ItemsPerPage)
                .Take(pageInfo.ItemsPerPage)
                .ToListAsync(token);

            return new PaginatedResult<Doctor>(
                doctors,
                pageInfo.Page,
                pageInfo.ItemsPerPage,
                totalRecords
            );
        }

        public async Task<Doctor?> GetByIdAsync(int id, CancellationToken token)
        {
            return await _context.Doctors.FindAsync(id,token);
        }
    }
}
