using Application.DTO.ServiceCategoryDTO;
using AutoMapper;
using Domain.Models;

namespace Presentation.Mapping.ServicesCategory
{
    public class ServicesCategoryMap : Profile
    {
        public ServicesCategoryMap()
        {
            CreateMap<ReadServiceCategoryDTO, ServiceCategory>();
            CreateMap<ServiceCategory, ReadServiceCategoryDTO>();

            CreateMap<CreateServiceCategoryDTO, ServiceCategory>();
            CreateMap<ServiceCategory, CreateServiceCategoryDTO>();

            CreateMap<UpdateServiceCategoryDTO, ServiceCategory>();
            CreateMap<ServiceCategory, UpdateServiceCategoryDTO>();
        }
    }
}
