using Application.DTO;
using Application.DTO.Result;
using Application.Service.Interface;
using AutoMapper;
using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.Repository.Interface;

namespace Application.Service.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IMapper mapper, IAppointmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<ReadAppointmentDTO>> CreateAsync(CreateAppointmentDTO dto, CancellationToken token)
        {
            var appointment = _mapper.Map<Appointment>(dto);

            await _repository.CreateAsync(appointment, token);
            await _repository.SaveChangesAsync(token);

            var result = _mapper.Map<ReadAppointmentDTO>(appointment);
            
            return Result<ReadAppointmentDTO>.SuccessResult(result);
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken token)
        {
            var appointment = await _repository.GetByIdAsync(id, token);
            if (appointment is null) return Result.NotFoundResult("Appointment is not found");

            _repository.Delete(appointment);
            await _repository.SaveChangesAsync(token);

            return Result.SuccessResult();
        }

        public async Task<Result<IReadOnlyCollection<ReadAppointmentDTO>>> GetAllAsync(
            PageInfo pageInfo, CancellationToken token)
        {
            var appointments = await _repository.GetAllAsync(pageInfo, token);
            var appointmentCollection = _mapper.Map<IReadOnlyCollection<ReadAppointmentDTO>>(appointments.Data);

            return Result<IReadOnlyCollection<ReadAppointmentDTO>>.SuccessResult(appointmentCollection);
        }

        public async Task<Result<ReadAppointmentDTO>> GetByIdAsync(int id, CancellationToken token)
        {
            var appointment = await _repository.GetByIdAsync(id, token);
            if (appointment is null) return Result<ReadAppointmentDTO>.NotFoundResult("Appointment is not found");

            var result = _mapper.Map<ReadAppointmentDTO>(appointment);

            return Result<ReadAppointmentDTO>.SuccessResult(result);
        }

        public async Task<Result<ReadAppointmentDTO>> UpdateAsync(int id, UpdateAppointmentDTO dto, CancellationToken token)
        {
            var appointment = await _repository.GetByIdAsync(id, token);
            if (appointment is null) return Result<ReadAppointmentDTO>.NotFoundResult("Appointment is not found");
            
            _mapper.Map(dto, appointment);
            await _repository.SaveChangesAsync(token);

            var resultDTO = _mapper.Map<ReadAppointmentDTO>(appointment);

            return Result<ReadAppointmentDTO>.SuccessResult(resultDTO);
        }
    }
}
