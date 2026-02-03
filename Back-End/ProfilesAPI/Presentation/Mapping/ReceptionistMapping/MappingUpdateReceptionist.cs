using Application.DTO.Receptionist;
using AutoMapper;
using Domain.DBServices.Models;

namespace Presentation.Mapping.ReceptionistMapping
{
    public class MappingUpdateReceptionist : Profile
    {
        public MappingUpdateReceptionist()
        {
            CreateMap<UpdateReceptionistDTO, Receptionist>();
            CreateMap<Receptionist, UpdateReceptionistDTO>();
        }
    }
}
