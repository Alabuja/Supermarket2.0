using System;
using Supermarket.Common.Models;
namespace Supermarket.Common.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public CategoryDTO Category{ get; set; }
    }
}
