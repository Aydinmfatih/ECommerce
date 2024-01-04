using AutoMapper;
using ECommerce.Services.Catalog.Dtos.CategoryDtos;
using ECommerce.Services.Catalog.Dtos.ProductDtos;
using ECommerce.Services.Catalog.Models;

namespace ECommerce.Services.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
           

            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();

            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();

        }

    }
}
