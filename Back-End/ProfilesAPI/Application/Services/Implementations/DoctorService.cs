using Application.DTO.Doctors;
using Application.DTO.Result;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorsRepository _repository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ReadDoctorDTO>> CreateAsync(CreateDoctorDTO doctorDTO, CancellationToken token)
        {
            var doctor = _mapper.Map<Doctor>(doctorDTO);

            await _repository.CreateAsync(doctor, token);
            await _repository.SaveDataAsync(token);

            var readDoctorDTO = _mapper.Map<ReadDoctorDTO>(doctor);

            return Result<ReadDoctorDTO>.SuccessResult(readDoctorDTO);
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken token)
        {
            var doctor = await _repository.GetByIdAsync(id, token);
            if (doctor == null) return Result.NotFoundResult("DoctorNotFound"); // TODO localize

            _repository.Delete(doctor);
            await _repository.SaveDataAsync(token);

            return Result.SuccessResult();
        }

        public async Task<Result<IReadOnlyCollection<ReadDoctorDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var doctors = await _repository.GetAllAsync(pageInfo, token);
            var doctorCollection = _mapper.Map<IReadOnlyCollection<ReadDoctorDTO>>(doctors.Data);

            return Result<IReadOnlyCollection<ReadDoctorDTO>>.SuccessResult(doctorCollection);
        }

        public async Task<Result<ReadDoctorDTO>> GetByIdAsync(int id, CancellationToken token)
        {
            var doctor = await _repository.GetByIdAsync(id, token);
            if (doctor == null) return Result<ReadDoctorDTO>.NotFoundResult("Doctor is not found");

            var doctorDTO = _mapper.Map<ReadDoctorDTO>(doctor);

            return Result<ReadDoctorDTO>.SuccessResult(doctorDTO);
        }

        public async Task<Result<ReadDoctorDTO>> UpdateAsync(int id, UpdateDoctorDTO doctorDTO, CancellationToken token)
        {
            var doctor = await _repository.GetByIdAsync(id, token);
            if (doctor is null) return Result<ReadDoctorDTO>.NotFoundResult("Doctor is not found");

            _mapper.Map(doctorDTO, doctor);
            await _repository.SaveDataAsync(token);

            var readDoctorDTO = _mapper.Map<ReadDoctorDTO>(doctor);

            return Result<ReadDoctorDTO>.SuccessResult(readDoctorDTO);
        }
    }
}
