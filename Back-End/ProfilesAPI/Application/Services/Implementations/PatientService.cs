using Application.DTO.Patients;
using Application.DTO.Result;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.DBServices.Models;
using Domain.DBServices.Models.PaginationModel;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientsRepository _repository;
        private readonly IMapper _mapper;

        public PatientService(IPatientsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ReadPatientDTO>> CreateAsync(CreatePatientDTO patientDTO, CancellationToken token)
        {
            var patient = _mapper.Map<Patient>(patientDTO);

            await _repository.CreateAsync(patient, token);
            await _repository.SaveDataAsync(token);

            var readPatientDTO = _mapper.Map<ReadPatientDTO>(patient);

            return Result<ReadPatientDTO>.SuccessResult(readPatientDTO);
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken token)
        {
            var patient = await _repository.GetByIdAsync(id, token);

            if (patient == null) return Result.NotFoundResult("Patient is not found");

            _repository.Delete(patient);
            await _repository.SaveDataAsync(token);

            return Result.SuccessResult();
        }

        public async Task<Result<IReadOnlyCollection<ReadPatientDTO>>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var patients = await _repository.GetAllAsync(pageInfo, token);

            var patientCollection = _mapper.Map<IReadOnlyCollection<ReadPatientDTO>>(patients.Data);

            return Result<IReadOnlyCollection<ReadPatientDTO>>.SuccessResult(patientCollection);
        }

        public async Task<Result<ReadPatientDTO>> GetByIdAsync(int id, CancellationToken token)
        {
            var patient = await _repository.GetByIdAsync(id, token);

            if (patient == null) return Result<ReadPatientDTO>.NotFoundResult("Patient not found");

            var patientDTO = _mapper.Map<ReadPatientDTO>(patient);

            return Result<ReadPatientDTO>.SuccessResult(patientDTO);
        }

        public async Task<Result<ReadPatientDTO>> UpdateAsync(int id, UpdatePatientDTO patientDTO, CancellationToken token)
        {
            var patient = await _repository.GetByIdAsync(id, token);
            if (patient is null) return Result<ReadPatientDTO>.NotFoundResult("Patient is not found");

            _mapper.Map(patientDTO, patient);
            await _repository.SaveDataAsync(token);

            var readPatientDTO = _mapper.Map<ReadPatientDTO>(patient);

            return Result<ReadPatientDTO>.SuccessResult(readPatientDTO);
        }
    }
}
