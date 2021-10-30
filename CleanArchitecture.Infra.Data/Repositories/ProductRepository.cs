using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _producContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _producContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _producContext.Add(product);
            await _producContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _producContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProducCategoryAsync(int? id)
        {
            return await _producContext.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _producContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _producContext.Remove(product);
            await _producContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _producContext.Update(product);
            await _producContext.SaveChangesAsync();
            return product;
        }
    }
}
