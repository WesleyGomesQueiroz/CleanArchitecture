using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Category> Create(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category> GetById(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> Delete(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
