using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data
{
    public class ProductRepository : IProductRepository
    {
        public StoreContext _storeContext { get; }
        public ProductRepository(StoreContext storeContext)
        {
_storeContext=storeContext;
        }

        public async Task<Product> GetProductAsync(int Id)
        {
            return await _storeContext.Products
            .Include(p=>p.ProductBrand)
            .Include(p=>p.ProductType)
            .FirstOrDefaultAsync(p=>p.Id==Id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storeContext.Products
            .Include(p=>p.ProductBrand)
            .Include(p=>p.ProductType)
            .ToListAsync();
        }
    }
}