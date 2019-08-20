using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.Common.Models;
using Supermarket.API.Services.Interface;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase 
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();

            return categories;
        }
    }
}