using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("product_attributes")]
    public class ProductAttribute
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        [Column("attribute_id")]
        public Guid AttributeId { get; set; }

        [ForeignKey("AttributeId")]
        public virtual Attribute Attribute { get; set; }
    }
}
