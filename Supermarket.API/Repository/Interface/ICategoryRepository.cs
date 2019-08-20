using Supermarket.Common.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Supermarket.API.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IQueryable<Category>> GetCategories();
        Task<Category> GetCategoryById(Guid categoryId);
        Task CreateCategory(Category category);
    }
}
