using AutoMapper;
using Supermarket.Common.Models;
using Supermarket.Common.BindingModel;
using Supermarket.Common.DTOs;
using System.Collections.Generic;

namespace Supermarket.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            Mapper.Initialize(cfg => {

                // Guest 
                cfg.CreateMap<CategoryBindingModel, Category>()
                    .ForMember(g => g.Id, opt => opt.Ignore());

                cfg.CreateMap<ProductBindingModel, Product>()
                    .ForMember(g => g.Id, opt => opt.Ignore());

                cfg.CreateMap<Product, ProductDTO>();

                cfg.CreateMap<Category, CategoryDTO>()
                    .ForMember(s => s.Products, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        dest.Products = Mapper.Map<List<ProductDTO>>(src.Products);
                    });

                cfg.CreateMap<Product, ProductDTO>()
                   .ForMember(g => g.Category, opt => opt.Ignore())
                   .AfterMap((src, dest) =>
                   {
                       dest.Category = Mapper.Map<CategoryDTO>(src.Category);
                   });

            });
        }
    }
}
