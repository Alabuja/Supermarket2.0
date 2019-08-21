using Supermarket.API.Repository.Interface;
using Supermarket.API.Services.Interface;
using Supermarket.Common.BindingModel;
using Supermarket.Common.Models;
using Supermarket.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Supermarket.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<CategoryDTO>> GetCategories()
        {
            var categoriesModel = await _categoryRepository.GetCategories();

            var results = _mapper.Map<List<CategoryDTO>>(categoriesModel);

            return results;
        }

        public async Task<CategoryDTO> GetCategoryById(Guid categoryId)
        {
            var categoryModel = await _categoryRepository.GetCategoryById(categoryId);

            var category = _mapper.Map<CategoryDTO>(categoryModel);

            return category;
        }

        public async Task CreateCategory(CategoryBindingModel categoryBinding)
        {
            var categoryModel   = _mapper.Map<Category>(categoryBinding);

            await _categoryRepository.CreateCategory(categoryModel);
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            await _categoryRepository.DeleteCategory(categoryId);
        }

        public async Task UpdateCategory(Guid categoryId, CategoryBindingModel categoryBindingModel)
        {
            var categoryModel   = _mapper.Map<Category>(categoryBindingModel);

            await _categoryRepository.UpdateCategory(categoryId, categoryModel);
        }
    }
}
