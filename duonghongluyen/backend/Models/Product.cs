using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }


        [Column("slug")]
        [MaxLength(255)]
        public string? Slug { get; set; }


        [Column("product_name")]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [Column("sku")]
        [MaxLength(255)]
        public string? SKU { get; set; }

        [Column("sale_price")]
        public decimal? SalePrice { get; set; }

        [Column("compare_price")]
        public decimal? ComparePrice { get; set; }

        [Column("buying_price")]
        public decimal? BuyingPrice { get; set; }


        [Column("quantity")]
        public int? Quantity { get; set; }

        [Column("short_description")]
        [MaxLength(165)]
        public string? ShortDescription { get; set; }

        [Column("product_description")]
        public string? ProductDescription { get; set; }

        [Column("product_type")]
        [MaxLength(64)]
        [RegularExpression("simple|variable", ErrorMessage = "Product type must be 'simple' or 'variable'")]
        public string? ProductType { get; set; }

        [Column("published")]
        public bool? Published { get; set; } = false;

        [Column("disable_out_of_stock")]
        public bool? DisableOutOfStock { get; set; } = true;

        [Column("note")]
        public string? Note { get; set; }

        [Column("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [Column("created_by")]
        public Guid? CreatedById { get; set; }

        [Column("updated_by")]
        public Guid? UpdatedById { get; set; }

        // Navigation properties
        [ForeignKey("CreatedById")]
        public virtual StaffAccount CreatedBy { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual StaffAccount UpdatedBy { get; set; }




        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
        // public virtual ICollection<Sell> Sells { get; set; }
        public virtual ICollection<CardItem> CardItems { get; set; }
        public virtual ICollection<ProductShipping> ProductShippings { get; set; }
        public virtual ICollection<ProductCoupon> ProductCoupons { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; }
        // public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }





        // Custom validation to ensure compare_price is greater than or equal to sale_price
        [NotMapped]
        [ComparePricesValidation]
        public bool ComparePricesValid => ComparePrice >= SalePrice || ComparePrice == 0;
    }

    // Custom validation attribute for comparing prices
    public class ComparePricesValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;

            if (product.ComparePrice < product.SalePrice && product.ComparePrice != 0)
            {
                return new ValidationResult("Compare price must be greater than or equal to sale price, or 0.");
            }

            return ValidationResult.Success;
        }
    }
}
