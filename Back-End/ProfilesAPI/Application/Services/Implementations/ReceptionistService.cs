using Application.DTO.Receptionist;
using Application.DTO.Result;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services.Implementations
{
    public class ReceptionistService : IReceptionistService
    {
        private readonly IMapper _mapper;
        private readonly IReceptionistsRepository _repository;

        public ReceptionistService(IMapper mapper, IReceptionistsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Result<ReadReceptionistDTO>> CreateAsync(
            CreateReceptionistDTO receptionistDTO, CancellationToken token)
        {
            var receptionist = _mapper.Map<Receptionist>(receptionistDTO);

            await _repository.CreateAsync(receptionist, token);
            await _repository.SaveDataAsync(token);

            var readReceptionistDTO = _mapper.Map<ReadReceptionistDTO>(receptionist);

            return Result<ReadReceptionistDTO>.SuccessResult(readReceptionistDTO);
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken token)
        {
            var receptionist = await _repository.GetByIdAsync(id, token);
            if (receptionist == null) return Result.NotFoundResult("Receptionist is not found");

            _repository.Delete(receptionist);
            await _repository.SaveDataAsync(token);

            return Result.SuccessResult();
        }

        public async Task<Result<IReadOnlyCollection<ReadReceptionistDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var receptionists = await _repository.GetAllAsync(pageInfo, token);
            var receptionistCollection = _mapper.Map<IReadOnlyCollection<ReadReceptionistDTO>>(receptionists.Data);

            return Result<IReadOnlyCollection<ReadReceptionistDTO>>.SuccessResult(receptionistCollection);
        }

        public async Task<Result<ReadReceptionistDTO>> GetByIdAsync(int id, CancellationToken token)
        {
            var receptionist = await _repository.GetByIdAsync(id, token);
            if (receptionist == null) return Result<ReadReceptionistDTO>.NotFoundResult("Receptionist is not found");

            var receptionistDTO = _mapper.Map<ReadReceptionistDTO>(receptionist);

            return Result<ReadReceptionistDTO>.SuccessResult(receptionistDTO);
        }
        
        public async Task<Result<ReadReceptionistDTO>> UpdateAsync(
            int id, UpdateReceptionistDTO receptionistDTO, CancellationToken token)
        {
            var updatedReceptionist = await _repository.GetByIdAsync(id, token);
            if (updatedReceptionist == null) return Result<ReadReceptionistDTO>.NotFoundResult("Receptionist is not found");

            _mapper.Map(receptionistDTO, updatedReceptionist);

            var readReceptionistDTO = _mapper.Map<ReadReceptionistDTO>(updatedReceptionist);

            return Result<ReadReceptionistDTO>.SuccessResult(readReceptionistDTO);
        }
    }
}
