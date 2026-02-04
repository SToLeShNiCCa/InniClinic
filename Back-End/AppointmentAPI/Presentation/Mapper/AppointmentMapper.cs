using Application.DTO;
using AutoMapper;
using Domain.Models;

namespace Presentation.Mapper
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<ReadAppointmentDTO, Appointment>();
            CreateMap<Appointment, ReadAppointmentDTO>();

            CreateMap<CreateAppointmentDTO, Appointment>();
            CreateMap<Appointment, CreateAppointmentDTO>();

            CreateMap<UpdateAppointmentDTO, Appointment>();
            CreateMap<Appointment, UpdateAppointmentDTO>();
        }
    }
}
