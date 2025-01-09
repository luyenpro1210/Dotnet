using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("variant_options")]
    public class VariantOption
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Column("image_id")]
        public Guid? ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual Gallery Image { get; set; }

        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("sale_price")]
        public decimal SalePrice { get; set; } = 0;

        [Column("compare_price")]
        [Range(0, double.MaxValue, ErrorMessage = "Compare price must be greater than or equal to sale price or 0.")]
        public decimal ComparePrice { get; set; } = 0;

        [Column("buying_price")]
        public decimal? BuyingPrice { get; set; }

        [Column("quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; } = 0;

        [Column("sku")]
        [MaxLength(255)]
        public string SKU { get; set; }

        [Column("active")]
        public bool Active { get; set; } = true;
    }
}
