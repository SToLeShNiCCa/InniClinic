using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Infrastructure.DbConfigurations.Contexts;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly ProfilesContext _context;

        public PatientsRepository(ProfilesContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Patient patient, CancellationToken token)
        {
            await _context.Patients.AddAsync(patient, token);
        }

        public void Delete(Patient patient)
        {
            _context.Remove(patient);
        }

        public async Task<PaginatedResult<Patient>> GetAllAsync(PageInfo param, CancellationToken token)
        {
            var query = _context.Patients
                .AsQueryable()
                .AsNoTracking();

            var totalRecords = await _context.Patients.CountAsync(token);

            var patients = await query
                .Skip((param.Page - 1) * param.ItemsPerPage)
                .Take(param.ItemsPerPage)
                .ToListAsync(token);

            return new PaginatedResult<Patient>
                (
                patients,
                param.Page,
                param.ItemsPerPage,
                totalRecords
                );
        }

        public async Task<Patient?> GetByIdAsync(int id, CancellationToken token)
        {
            return await _context.Patients.FindAsync(id, token);
        }

        public async Task SaveDataAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}
