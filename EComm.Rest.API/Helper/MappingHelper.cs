using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EComm.Rest.API.DTO;
using EComm.Rest.API.Entities;

namespace EComm.Rest.API.Helper
{
    public class MappingHelper : Profile
    {
        public MappingHelper()
        {
            CreateMap<Product, ProductResponseModel>()
                    .ForMember(p => p.ProductBrand, t => t.MapFrom(s => s.ProductBrand.Name))
                    .ForMember(t => t.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                    .ForMember(t => t.PictureUrl, o=> o.MapFrom<ProductUrlResolver>());
        }
    }
}