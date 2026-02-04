using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.DBConfiguration.ServiceContext;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {
        private readonly ServicesContext _servicesContext;

        public ServiceCategoryRepository(ServicesContext servicesContext)
        {
            _servicesContext = servicesContext;
        }

        public async Task CreateAsync(ServiceCategory serviceCategory, CancellationToken token)
        {
            await _servicesContext.ServiceCategories.AddAsync(serviceCategory, token);
        }

        public void Delete(ServiceCategory serviceCategory)
        {
            _servicesContext.ServiceCategories.Remove(serviceCategory);
        }

        public async Task<PaginatedResult<ServiceCategory>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var query = _servicesContext.ServiceCategories
                .AsQueryable()
                .AsNoTracking();

            var totalRecords = await _servicesContext.ServiceCategories.CountAsync(token);

            var serviceCategories = await query
                .Skip((pageInfo.Page - 1) * pageInfo.ItemsPerPage)
                .Take(pageInfo.ItemsPerPage)
                .ToListAsync(token);

            return new PaginatedResult<ServiceCategory>
                (
                serviceCategories,
                pageInfo.Page,
                pageInfo.ItemsPerPage,
                totalRecords
                );
        }

        public async Task<ServiceCategory?> GetByIdAsync(int id, CancellationToken token)
        {
            return await _servicesContext.ServiceCategories.FindAsync(id, token);
        }

        public async Task SaveDataAsync(CancellationToken token)
        {
            await _servicesContext.SaveChangesAsync(token);
        }
    }
}
