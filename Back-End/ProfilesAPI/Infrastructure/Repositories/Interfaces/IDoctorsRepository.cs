using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IDoctorsRepository
    {
        Task<PaginatedResult<Doctor>> GetAllAsync(PageInfo param, CancellationToken token);
        Task<Doctor?> GetByIdAsync(int id, CancellationToken token);
        Task CreateAsync(Doctor doctor, CancellationToken token);
        void Delete(Doctor doctor);
        Task SaveDataAsync(CancellationToken token);
    }
}
