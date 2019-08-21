using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Common.Models
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get;set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}