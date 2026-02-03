using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Infrastructure.DbConfigurations.Contexts;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class ReceptionistsRepository : IReceptionistsRepository
    {
        private readonly ProfilesContext _context;

        public ReceptionistsRepository(ProfilesContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Receptionist receptionist, CancellationToken token)
        {
            await _context.Receptionists.AddAsync(receptionist, token);
        }

        public void Delete(Receptionist receptionist)
        {
            _context.Remove(receptionist);
        }

        public async Task<PaginatedResult<Receptionist>> GetAllAsync(PageInfo param, CancellationToken token)
        {
            var query = _context.Receptionists
                .AsQueryable()
                .AsNoTracking();

            var totalRecords = await _context.Receptionists.CountAsync(token);

            var receptionists = await query
                .Skip((param.Page - 1) * param.ItemsPerPage)
                .Take(param.ItemsPerPage)
                .ToListAsync(token);

            return new PaginatedResult<Receptionist>
                (
                receptionists,
                param.Page,
                param.ItemsPerPage,
                totalRecords
                );

        }

        public async Task<Receptionist?> GetByIdAsync(int id, CancellationToken token)
        {
            return await _context.Receptionists.FindAsync(id, token);
        }

        public async Task SaveDataAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}
