using Supermarket.API.Repository.Interface;
using Supermarket.API.Services.Interface;
using Supermarket.Common.DTOs;
using Supermarket.Common.BindingModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Supermarket.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<IList<CategoryDTO>> GetCategories()
        {
            
        }

        public async Task<CategoryDTO> GetCategoryById(Guid categoryId)
        {

        }

        public async Task CreateCategory(CategoryBindingModel categoryBinding)
        {

        }
    }
}
