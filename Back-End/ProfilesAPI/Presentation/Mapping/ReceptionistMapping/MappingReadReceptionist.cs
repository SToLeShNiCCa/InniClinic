using Application.DTO.Receptionist;
using AutoMapper;
using Domain.DBServices.Models;

namespace Presentation.Mapping.ReceptionistMapping
{
    public class MappingReadReceptionist : Profile
    {
        public MappingReadReceptionist()
        {
            CreateMap<ReadReceptionistDTO, Receptionist>();
            CreateMap<Receptionist, ReadReceptionistDTO>();
        }
    }
}
