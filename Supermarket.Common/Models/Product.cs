using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Common.Models
{
    [Table("Products")]
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}