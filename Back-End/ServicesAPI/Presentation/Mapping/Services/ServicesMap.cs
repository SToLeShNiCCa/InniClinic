using Application.DTO.ServiceDTO;
using AutoMapper;
using Domain.Models;

namespace Presentation.Mapping.Services
{
    public class ServicesMap : Profile
    {
        public ServicesMap()
        {
            CreateMap<ReadServiceDTO, Service>();
            CreateMap<Service, ReadServiceDTO>();

            CreateMap<CreateServiceDTO, Service>();
            CreateMap<Service , CreateServiceDTO>();

            CreateMap<UpdateServiceDTO , Service>();
            CreateMap<Service, UpdateServiceDTO>();
        }
    }
}
