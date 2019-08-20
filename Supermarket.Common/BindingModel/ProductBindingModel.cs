using System;
using Supermarket.Common.Models;

namespace Supermarket.Common.BindingModel
{
    public class ProductBindingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public Guid CategoryId { get; set; }
    }
}