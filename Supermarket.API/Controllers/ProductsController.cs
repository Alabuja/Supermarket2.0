using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Services.Interface;
using Supermarket.Common.DTOs;
using Supermarket.Common.Helpers;
using Supermarket.Common.BindingModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    /// <summary>
    /// Products Class
    /// </summary>
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase 
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<ProductDTO>> GetProducts()
        {
            var products = await _productService.GetProducts();

            return products;
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProductById(Guid productId)
        {
            var product = await _productService.GetProductById(productId);

            if (product.IsNull()) return NotFound("Product not found");
            
            return product;
        }

        /// <summary>
        /// Post Product
        /// </summary>
        /// <param name="productBindingModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PostProduct([FromBody]ProductBindingModel productBindingModel)
        {
            await _productService.CreateProduct(productBindingModel);

            return CreatedAtAction(nameof(productBindingModel), new { Id = productBindingModel.Id }, productBindingModel);
        }

        /// <summary>
        /// Change Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productBindingModel"></param>
        /// <returns></returns>

        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutProduct(Guid productId, [FromBody]ProductBindingModel productBindingModel)
        {
            var product = _productService.GetProductById(productId);

            if(productBindingModel.IsNull()) return BadRequest("Product Fields cannot be empty");

            if(product.IsNull()) return NotFound("Product not found");

            await _productService.UpdateProduct(productId, productBindingModel);

            return Ok();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(Guid productId)
        {
            var category = _productService.GetProductById(productId);

            if(category.IsNull()) return NotFound("Product not found");

            await _productService.DeleteProduct(productId);

            return NoContent();
        }
    }
}