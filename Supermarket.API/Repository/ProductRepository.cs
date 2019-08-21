using Supermarket.API.Data;
using Supermarket.API.Repository.Interface;
using Supermarket.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(SupermarketDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var categories = await _context.Products.ToListAsync();
            
            return categories;
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            var product = await GetProduct(productId);

            return product;
        }
        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid productId)
        {
            var product = await GetProduct(productId);

            _context.Entry<Product>(product).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Guid productId, Product productModel)
        {
            var product = await GetProduct(productId);

            product.Name = productModel.Name;
            product.QuantityInStock = productModel.QuantityInStock;
            product.UnitOfMeasurement = productModel.UnitOfMeasurement;
            product.CategoryId  =  productModel.CategoryId;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        private async Task<Product> GetProduct(Guid productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            return product;
        }
    }
}
