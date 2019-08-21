using Microsoft.EntityFrameworkCore;
using Supermarket.API.Data;
using Supermarket.API.Repository.Interface;
using Supermarket.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(SupermarketDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Categories.Where(p => p.IsDeleted != true).ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            var category = await GetCategory(categoryId);

            return category;
        }
        public async Task CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var category = await GetCategory(categoryId);

            category.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Guid categoryId, Category categoryModel)
        {
            var category = await GetCategory(categoryId);
            
            category.Name = categoryModel.Name;

            await _context.SaveChangesAsync();
        }


        private async Task<Category> GetCategory(Guid categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == categoryId);
            return category;
        }
    }
}
