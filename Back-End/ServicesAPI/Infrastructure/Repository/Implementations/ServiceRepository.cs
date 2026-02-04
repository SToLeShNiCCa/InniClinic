using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.DBConfiguration.ServiceContext;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ServicesContext _servicesContext;

        public ServiceRepository(ServicesContext services)
        {
            _servicesContext = services;
        }

        public async Task CreateAsync(Service service, CancellationToken token)
        {
            await _servicesContext.Services.AddAsync(service, token);
        }

        public void Delete(Service service)
        {
            _servicesContext.Services.Remove(service);
        }

        public async Task<PaginatedResult<Service>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var query = _servicesContext.Services
                .AsQueryable()
                .AsNoTracking();

            var totalRecords = await _servicesContext.Services.CountAsync();

            var services = await query
                .Skip((pageInfo.Page - 1)* pageInfo.ItemsPerPage)
                .Take(pageInfo.ItemsPerPage)
                .ToListAsync();

            return new PaginatedResult<Service>
                (
                    services,
                    pageInfo.Page,
                    pageInfo.ItemsPerPage,
                    totalRecords
                );
        }

        public async Task<Service?> GetByIdAsync(int id, CancellationToken token)
        {
            return await _servicesContext.Services.FindAsync(id, token);
        }

        public async Task SaveDataAsync(CancellationToken token)
        {
            await _servicesContext.SaveChangesAsync(token);
        }
    }
}
