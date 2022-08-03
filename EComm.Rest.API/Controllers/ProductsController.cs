using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EComm.Model.Interfaces;
using EComm.Model.Specifications;
using EComm.Rest.API.Data;
using EComm.Rest.API.DTO;
using EComm.Rest.API.Entities;
using EComm.Rest.API.Errors;
using EComm.Rest.API.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EComm.Rest.API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        
        private readonly ILogger<ProductsController> _logger;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger,
        IGenericRepository<Product> productRepo,
        IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper)
        {
            _logger = logger;
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
           _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<ProductResponseModel>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            _logger.LogInformation("GetProducts Triggered");
            var spec = new ProductsWithTypesandBrandsSpec(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);
            _logger.LogInformation("total items count : "+ totalItems);
            //_logger.LogInformation("PageIndex : "+ totalItems);
            //_logger.LogInformation("total items count : "+ totalItems);
            var respData = _mapper
                            .Map<IReadOnlyList<ProductResponseModel>>(products);
            return Ok(new Pagination<ProductResponseModel>(productParams.PageIndex,productParams.PageSize,totalItems,respData));
            
           
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductResponseModel>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesandBrandsSpec(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if(product == null) return NotFound(new APIResponse(404));

            return _mapper.Map<Product, ProductResponseModel>(product);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());

        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());

        }

    }
}