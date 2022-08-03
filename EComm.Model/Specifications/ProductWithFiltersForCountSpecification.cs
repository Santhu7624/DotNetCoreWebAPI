using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Rest.API.Entities;

namespace EComm.Model.Specifications
{
    public class ProductWithFiltersForCountSpecification  : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification( ProductSpecParams productParams)
            :base(x => 
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))&&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {

        }
    }
}