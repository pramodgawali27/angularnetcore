using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastucture.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext,ILoggerFactory loggerFactory){
          try{
             if(!storeContext.ProductBrand.Any()){
                var brandData=File.ReadAllText("../Infrastucture/Data/SeedData/brands.json");
                var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                 foreach(var brand in brands){
                      storeContext.Add(brand);
             }
             await storeContext.SaveChangesAsync();
    }
    if(!storeContext.ProductType.Any()){
                var productType=File.ReadAllText("../Infrastucture/Data/SeedData/types.json");
                var productTypes=JsonSerializer.Deserialize<List<ProductType>>(productType);
                 foreach(var item in productTypes){
                      storeContext.Add(item);
             }
             await storeContext.SaveChangesAsync();
    }
    if(!storeContext.Products.Any()){
                var products=File.ReadAllText("../Infrastucture/Data/SeedData/products.json");
                var allProducts=JsonSerializer.Deserialize<List<Product>>(products);
                 foreach(var item in allProducts){
                      storeContext.Add(item);
             }
             await storeContext.SaveChangesAsync();
    }
}
catch(Exception ex){
var logger=loggerFactory.CreateLogger<StoreContextSeed>();
logger.LogError(ex.Message);
}
        }
    }
}