using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trial.WebAPI.Data;
using Trial.WebAPI.Data.Factory;
using Trial.WebAPI.Data.Models;

namespace Trial.WebAPI.Services
{
    public class ProductsService : IProductsService, IDisposable
    {
        bool _disposed;

        private readonly MainDbContext _context;

        public ProductsService(IContextFactory contextFactory, IMapper mapper)
        {
            _context = contextFactory.GetContext();
        }

        public async Task<IEnumerable<Product>> GetAllProductsData(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetProduct(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new ArgumentException($"Couldn't find product with id: {id}.");
            }

            return product;
        }

        public async Task CreateProduct(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateProduct(Product product, CancellationToken cancellationToken)
        {            
            var foundProduct = await _context.Products
                .AsNoTracking()
                .Where(p => p.Id == product.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            
            if (foundProduct == null)
            {
                throw new ArgumentException($"Couldn't find product with id: {product.Id}.");
            }

            _context.Products.Update(product);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var foundProduct = await _context.Products.FindAsync(id);

            if (foundProduct == null)
            {
                throw new ArgumentException($"Couldn't find product with id: {id}.");
            }

            _context.Products.Remove(foundProduct);

            await _context.SaveChangesAsync(cancellationToken);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}