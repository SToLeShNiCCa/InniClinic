using Application.DTO;
using Application.DTO.Result;
using Application.Services.Interface;
using AutoMapper;
using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.Repository.Interface;

namespace Application.Services.Implementation
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _repository;
        private readonly IMapper _mapper;
        public OfficeService(IOfficeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ReadOfficeDTO>> CreateAsync(CreateOfficeDTO dto, CancellationToken token)
        {
            var newOffice = _mapper.Map<Office>(dto);

            await _repository.CreateAsync(newOffice, token);

            var result = _mapper.Map<ReadOfficeDTO>(newOffice);

            return Result<ReadOfficeDTO>.SuccessResult(result);
        }

        public async Task<Result<IReadOnlyCollection<ReadOfficeDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var officeCollection = await _repository.GetAllAsync(pageInfo, token);
            var result = _mapper.Map<IReadOnlyCollection<ReadOfficeDTO>>(officeCollection.Data);

            return Result<IReadOnlyCollection<ReadOfficeDTO>>.SuccessResult(result);
        }

        public async Task<Result<ReadOfficeDTO>> GetByIdAsync(string id, CancellationToken token)
        {
            var office = await _repository.GetByIdAsync(id, token);
            if (office is null) return Result<ReadOfficeDTO>.NotFoundResult("Office is not found");

            var result = _mapper.Map<ReadOfficeDTO>(office);

            return Result<ReadOfficeDTO>.SuccessResult(result);
        }

        public async Task<Result> RemoveAsync(string id, CancellationToken token)
        {
            await _repository.RemoveAsync(id, token);
            return Result.SuccessResult();
        }

        public async Task<Result<ReadOfficeDTO>> Update(string id, UpdateOfficeDTO dto, CancellationToken token)
        {
            var updatedOffice = _mapper.Map<Office>(dto);

            await _repository.Update(id, updatedOffice, token);

            var result = _mapper.Map<ReadOfficeDTO>(updatedOffice);

            return Result<ReadOfficeDTO>.SuccessResult(result);
        }
    }
}
