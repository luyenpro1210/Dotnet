using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("variants")]
    public class Variant
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("variant_attribute_value_id")]
        public Guid VariantAttributeValueId { get; set; }

        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        //  public virtual ICollection<VariantAttributeValue> VariantAttributeValues { get; set; }

    }
}
