using Application.DTO.Result;
using Application.DTO.ServiceDTO;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.Repository.Interfaces;

namespace Application.Services.Implementations
{
    public class ServiceServices : IServiceServices
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public ServiceServices(IServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ReadServiceDTO>> CreateAsync(CreateServiceDTO serviceDTO, CancellationToken token)
        {
            var service = _mapper.Map<Service>(serviceDTO);

            await _repository.CreateAsync(service, token);
            await _repository.SaveDataAsync(token);

            var resultDTO = _mapper.Map<ReadServiceDTO>(service);

            return Result<ReadServiceDTO>.SuccessResult(resultDTO);
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken token)
        {
            var result = await _repository.GetByIdAsync(id, token);
            if (result is null) return Result.NotFoundResult("Service is not found");

            _repository.Delete(result);
            await _repository.SaveDataAsync(token);

            return Result.SuccessResult();
        }

        public async Task<Result<IReadOnlyCollection<ReadServiceDTO>>> GetAllAsync(
            PageInfo pageInfo, CancellationToken token)
        {
            var services =  await _repository.GetAllAsync(pageInfo, token);
            var serviceCollection = _mapper.Map<IReadOnlyCollection<ReadServiceDTO>>(services.Data);

            return Result<IReadOnlyCollection<ReadServiceDTO>>.SuccessResult(serviceCollection);
        }

        public async Task<Result<ReadServiceDTO>> GetByIdAsync(int id, CancellationToken token)
        {
            var result = await _repository.GetByIdAsync(id, token);
            if (result is null) return Result<ReadServiceDTO>.NotFoundResult("Service is not found");

            var resultDTO = _mapper.Map<ReadServiceDTO>(result);

            return Result<ReadServiceDTO>.SuccessResult(resultDTO);
        }

        public async Task<Result<ReadServiceDTO>> UpdateAsync(
            int id, UpdateServiceDTO serviceDTO, CancellationToken token)
        {
            var service = await _repository.GetByIdAsync(id, token);
            if(service is null)return Result<ReadServiceDTO>.NotFoundResult("Service is not found");

            _mapper.Map(serviceDTO, service);
            await _repository.SaveDataAsync(token);

            var resultDTO = _mapper.Map<ReadServiceDTO>(service);

            return Result<ReadServiceDTO>.SuccessResult(resultDTO);
        }
    }
}
