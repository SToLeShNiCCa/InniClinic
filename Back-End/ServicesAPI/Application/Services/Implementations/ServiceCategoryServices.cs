using Application.DTO.Result;
using Application.DTO.ServiceCategoryDTO;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.Repository.Interfaces;

namespace Application.Services.Implementations
{
    public class ServiceCategoryServices : IServiceCategoryServices
    {
        private readonly IServiceCategoryRepository _repository;
        private readonly IMapper _mapper;

        public ServiceCategoryServices(IServiceCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ReadServiceCategoryDTO>> CreateAsync(
            CreateServiceCategoryDTO serviceCategoryDTO,CancellationToken token)
        {
            var serviceCategory = _mapper.Map<ServiceCategory>(serviceCategoryDTO);

            await _repository.CreateAsync(serviceCategory, token);
            await _repository.SaveDataAsync(token);

            var resultDTO = _mapper.Map<ReadServiceCategoryDTO>(serviceCategory);

            return Result<ReadServiceCategoryDTO>.SuccessResult(resultDTO);
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken token)
        {
            var serviceCategory = await _repository.GetByIdAsync(id, token);
            if (serviceCategory is null) return Result.NotFoundResult("DoctorNotFound");

            _repository.Delete(serviceCategory);
            await _repository.SaveDataAsync(token);

            return Result.SuccessResult();
        }

        public async Task<Result<IReadOnlyCollection<ReadServiceCategoryDTO>>> GetAllAsync(
            PageInfo pageInfo,CancellationToken token)
        {
            var serviceCategory = await _repository.GetAllAsync(pageInfo, token);
            var serviceCategoryCollection = _mapper.Map<IReadOnlyCollection<ReadServiceCategoryDTO>>(serviceCategory.Data);

            return Result<IReadOnlyCollection<ReadServiceCategoryDTO>>.SuccessResult(serviceCategoryCollection);
        }

        public async Task<Result<ReadServiceCategoryDTO>> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _repository.GetByIdAsync(id, token);
            if (result is null) return Result<ReadServiceCategoryDTO>.NotFoundResult("Service category is not found");

            var resultDTO = _mapper.Map<ReadServiceCategoryDTO>(result);

            return Result<ReadServiceCategoryDTO>.SuccessResult(resultDTO);
        }

        public async Task<Result<ReadServiceCategoryDTO>> UpdateAsync(
            int id, UpdateServiceCategoryDTO serviceCategoryDTO, CancellationToken token)
        {
            var result = await _repository.GetByIdAsync(id, token);
            if(result is null) return Result<ReadServiceCategoryDTO>.NotFoundResult("Service category is not found");

            _mapper.Map(serviceCategoryDTO, result);
            await _repository.SaveDataAsync(token);

            var resultDTO = _mapper.Map<ReadServiceCategoryDTO>(result);

            return Result<ReadServiceCategoryDTO>.SuccessResult(resultDTO);
        }
    }
}
