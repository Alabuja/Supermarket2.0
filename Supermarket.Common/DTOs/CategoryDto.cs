using System;
using Supermarket.Common.DTOs;
using System.Collections.Generic;

namespace Supermarket.Common.DTOs
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            Products = new List<ProductDTO>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
