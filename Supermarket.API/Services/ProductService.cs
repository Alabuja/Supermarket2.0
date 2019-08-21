using Supermarket.API.Repository.Interface;
using Supermarket.API.Services.Interface;
using Supermarket.Common.DTOs;
using Supermarket.Common.BindingModel;
using Supermarket.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace Supermarket.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<ProductDTO>> GetProducts()
        {
            var productsModel = await _productRepository.GetProducts();

            var results = _mapper.Map<List<ProductDTO>>(productsModel);

            return results;
        }

        public async Task<ProductDTO> GetProductById(Guid productId)
        {
            var productModel = await _productRepository.GetProductById(productId);

            var product = _mapper.Map<ProductDTO>(productModel);

            return product;
        }

        public async Task CreateProduct(ProductBindingModel productBindingModel)
        {
            var productModel    =   _mapper.Map<Product>(productBindingModel);

            await _productRepository.CreateProduct(productModel);
        }

        public async Task DeleteProduct(Guid productId)
        {
            await _productRepository.DeleteProduct(productId);
        }

        public async Task UpdateProduct(Guid productId, ProductBindingModel productBindingModel)
        {
            var productModel = _mapper.Map<Product>(productBindingModel);

            await _productRepository.UpdateProduct(productId, productModel);
        }
    }
}
