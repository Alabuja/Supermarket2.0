using Supermarket.Common.BindingModel;
using Supermarket.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Services.Interface
{
    public interface ICategoryService
    {
        Task<IList<CategoryDTO>> GetCategories();
        Task CreateCategory(CategoryBindingModel categoryBinding);
        Task<CategoryDTO> GetCategoryById(Guid categoryId);
        Task DeleteCategory(Guid categoryId);
        Task UpdateCategory(Guid categoryId, CategoryBindingModel category);
    }
}
