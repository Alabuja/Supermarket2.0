using Supermarket.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(Guid categoryId);
        Task CreateCategory(Category category);
        Task DeleteCategory(Guid categoryId);
        Task UpdateCategory(Guid categoryId, Category category);
    }
}
