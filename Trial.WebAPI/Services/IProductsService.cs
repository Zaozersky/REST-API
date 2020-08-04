using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Trial.WebAPI.Data.Models;

namespace Trial.WebAPI.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsData(CancellationToken cancellationToken);
        Task<Product> GetProduct(int id, CancellationToken cancellationToken);
        Task CreateProduct(Product product, CancellationToken cancellationToken);
        Task UpdateProduct(Product product, CancellationToken cancellationToken);
        Task DeleteProduct(int id, CancellationToken cancellationToken);
    }
}