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
    public interface IPatientsRepository
    {
        Task<PaginatedResult<Patient>> GetAllAsync(PageInfo param, CancellationToken token);
        Task<Patient?> GetByIdAsync(int id, CancellationToken token);
        Task CreateAsync(Patient patient, CancellationToken token);
        void Delete(Patient patient);
        Task SaveDataAsync(CancellationToken token);
    }
}
