using Supermarket.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Supermarket.API.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(Guid productId);
        Task CreateProduct(Product product);
        Task DeleteProduct(Guid productId);
        Task UpdateProduct(Guid productId, Product product);
    }
}
