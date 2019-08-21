using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Common.Models
{
    [Table("Categories")]
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get;set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}