using Application.DTO.Receptionist;
using AutoMapper;
using Domain.DBServices.Models;

namespace Presentation.Mapping.ReceptionistMapping
{
    /// <summary>
    /// AutoMapper profile for mapping between Receptionists and DTOReceptionist.
    /// </summary>
    public class MappingCreateReceptionist : Profile
    {
        public MappingCreateReceptionist()
        {
            // Mapping configuration between Receptionists and DTOReceptionist
            CreateMap<CreateReceptionistDTO, Receptionist>();
            // Reverse mapping
            CreateMap<Receptionist, CreateReceptionistDTO>();
        }
    }
}
