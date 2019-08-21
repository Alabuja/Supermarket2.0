using Supermarket.Common.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Supermarket.API.Repository.Interface
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();
        Task<Category> GetCategoryById(Guid categoryId);
        Task CreateCategory(Category category);
        Task DeleteCategory(Guid categoryId);
        Task UpdateCategory(Guid categoryId, Category category);
    }
}
