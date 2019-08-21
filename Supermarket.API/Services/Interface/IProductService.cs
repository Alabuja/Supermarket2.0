using Supermarket.Common.BindingModel;
using Supermarket.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Services.Interface
{
    public interface IProductService
    {
        Task<IList<ProductDTO>> GetProducts();
        Task CreateProduct(ProductBindingModel productBindingModel);
        Task<ProductDTO> GetProductById(Guid productId);
        Task DeleteProduct(Guid productId);
        Task UpdateProduct(Guid productId, ProductBindingModel productBindingModel);
    }
}
