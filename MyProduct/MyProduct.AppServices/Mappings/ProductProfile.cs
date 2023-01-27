using AutoMapper;
using MyProduct.AppServices.DTOs;
using MyProduct.Domain.Entities;

namespace MyProduct.AppServices.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
        }
    }
}
