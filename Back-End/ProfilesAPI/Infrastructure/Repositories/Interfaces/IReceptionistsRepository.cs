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
    public interface IReceptionistsRepository
    {
        Task<PaginatedResult<Receptionist>> GetAllAsync(PageInfo param, CancellationToken token);
        Task<Receptionist?> GetByIdAsync(int id, CancellationToken token);
        Task CreateAsync(Receptionist receptionist, CancellationToken token);
        void Delete(Receptionist receptionist);
        Task SaveDataAsync(CancellationToken token);
    }
}
