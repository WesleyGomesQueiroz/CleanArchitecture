using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Products.Commands;

namespace CleanArchitecture.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
