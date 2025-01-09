using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace duonghongluyen.Exercise02.DTOs
{
    public class ProductDTO
    {
        public Guid? Id { get; set; }
        [MaxLength(255)]
        public string? ProductName { get; set; }


        public decimal? SalePrice { get; set; }

        public decimal? BuyingPrice { get; set; }

        public List<Guid> ProductCategoryIds { get; set; }
        public List<string> ProductCategoryNames { get; set; }
    }
}
