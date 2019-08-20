using Supermarket.API.Data;
using Supermarket.API.Repository.Interface;
using Supermarket.Common.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(SupermarketDbContext context) : base(context)
        {

        }

        public async Task<IQueryable<Category>> GetCategories()
        {
            
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            
        }
        public async Task CreateCategory(Category category)
        {

        }
    }
}
