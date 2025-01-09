using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("product_attribute_values")]
    public class ProductAttributeValue
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("product_attribute_id")]
        public Guid ProductAttributeId { get; set; }

        [ForeignKey("ProductAttributeId")]
        public virtual ProductAttribute ProductAttribute { get; set; }

        [Required]
        [Column("attribute_value_id")]
        public Guid AttributeValueId { get; set; }

        [ForeignKey("AttributeValueId")]
        public virtual AttributeValue AttributeValue { get; set; }
    }
}
