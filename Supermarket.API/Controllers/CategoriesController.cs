using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Services.Interface;
using Supermarket.Common.BindingModel;
using Supermarket.Common.DTOs;
using Supermarket.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    /// <summary>
    /// Categories Class
    /// </summary>
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase 
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<CategoryDTO>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();

            return categories;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(Guid categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);

            if (category.IsNull()) return NotFound();
            
            return category;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoriesBindingModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PostCategory([FromBody]CategoryBindingModel categoriesBindingModel)
        {
            await _categoryService.CreateCategory(categoriesBindingModel);

            return CreatedAtAction(nameof(GetCategoryById), new { Id = categoriesBindingModel.Id }, categoriesBindingModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="categoriesBindingModel"></param>
        /// <returns></returns>
        [HttpPut("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutCategory(Guid categoryId, [FromBody]CategoryBindingModel categoriesBindingModel)
        {
            var category = _categoryService.GetCategoryById(categoryId);

            if(categoriesBindingModel.IsNull())
            {
                return BadRequest("Category Fields cannot be empty");
            }

            if (category.IsNull())
            {
                return NotFound("Category not found");
            }

            await _categoryService.UpdateCategory(categoryId, categoriesBindingModel);

            return Ok();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCategory(Guid categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);

            if (category.IsNull()) return NotFound("Category not found");

            await _categoryService.DeleteCategory(categoryId);

            return NoContent();
        }
    }
}