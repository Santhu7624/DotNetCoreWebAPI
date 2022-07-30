using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Model.Interfaces;
using EComm.Rest.API.Data;
using EComm.Rest.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EComm.DataAccess.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext  context)
        {
            _context= context;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id==id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypessAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}