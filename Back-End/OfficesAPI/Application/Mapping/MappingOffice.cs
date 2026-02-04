using Application.DTO;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping
{
    public class MappingOffice : Profile
    {
        public MappingOffice()
        {
            CreateMap<ReadOfficeDTO, Office>();
            CreateMap<Office, ReadOfficeDTO>();

            CreateMap<CreateOfficeDTO, Office>();
            CreateMap<Office, CreateOfficeDTO>();

            CreateMap<UpdateOfficeDTO, Office>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Office, UpdateOfficeDTO>();
        }
    }
}
