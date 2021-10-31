using CleanArchitecture.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();

        Task<CategoryDTO> GetBiIdAsync(int? id);

        Task AddAsync(CategoryDTO categoryDto);
        
        Task UpdateAsync(CategoryDTO categoryDto);
        
        Task RemoveAsync(int? id);
    }
}
