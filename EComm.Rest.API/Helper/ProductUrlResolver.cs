using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Rest.API.DTO;
using EComm.Rest.API.Entities;
using AutoMapper;

namespace EComm.Rest.API.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductResponseModel, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;

        }
        public string Resolve(Product product, ProductResponseModel destination, string destMember, 
        ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(product.PictureUrl))
            {
                return _config["ApiUrl"] + product.PictureUrl;
            }
            return null;
        }
    }
}