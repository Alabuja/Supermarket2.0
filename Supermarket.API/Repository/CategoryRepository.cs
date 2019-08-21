using Supermarket.API.Data;
using Supermarket.API.Repository.Interface;
using Supermarket.Common.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(SupermarketDbContext context) : base(context)
        {

        }

        public IQueryable<Category> GetCategories()
        {
            var categories = _context.Categories.Where(p => p.IsDeleted != true);

            categories = categories.AsQueryable();
            
            return categories;
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            return category;
        }
        public async Task CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == categoryId);

            category.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Guid categoryId, Category category)
        {
            await _context.SaveChangesAsync();
        }
    }
}
