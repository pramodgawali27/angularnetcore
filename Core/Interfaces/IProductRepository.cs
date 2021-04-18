using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {

         Task<Product> GetProductAsync(int Id);
         Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}