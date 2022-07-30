using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EComm.Rest.API.Data;
using EComm.Rest.API.Entities;
using Microsoft.Extensions.Logging;

namespace EComm.DataAccess.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory logger)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var productBrandsData = File.ReadAllText("../EComm.DataAccess/Data/SeedData/brands.json");
                    
                        var productBrands = JsonSerializer
                                        .Deserialize<List<ProductBrand>>(productBrandsData);
                        foreach(var item in productBrands)
                        {
                            context.ProductBrands.Add(item);
                        }
                        await context.SaveChangesAsync();
                    
                }

                 if(!context.ProductTypes.Any())
                {
                    var productTypeData = File.ReadAllText("../EComm.DataAccess/Data/SeedData/types.json");
                    
                        var productTypes = JsonSerializer
                                        .Deserialize<List<ProductType>>(productTypeData);
                        foreach(var item in productTypes)
                        {
                            context.ProductTypes.Add(item);
                        }
                        await context.SaveChangesAsync();
                    
                }
                if(!context.Products.Any())
                {
                    var productData = File.ReadAllText("../EComm.DataAccess/Data/SeedData/products.json");
                    
                        var products = JsonSerializer.Deserialize<List<Product>>(productData);
                        foreach(var item in products)
                        {
                            context.Products.Add(item);
                        }
                        await context.SaveChangesAsync();
                    
                }

            }
            catch(Exception ex)
            {
                var _logger = logger.CreateLogger<StoreContextSeed>();
                _logger.LogError(ex.Message);
            }
        }
    }
}