using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("attribute_values")]
    public class AttributeValue
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column("attribute_id")]
        public Guid AttributeId { get; set; }

        [ForeignKey("AttributeId")]
        public virtual Attribute Attribute { get; set; }

        [Column("attribute_value")]
        [MaxLength(255)]
        public string Value { get; set; }

        [Column("color")]
        [MaxLength(50)]
        public string? Color { get; set; }

        // public virtual ICollection<VariantAttributeValue> VariantAttributeValues { get; set; }

        // public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }

    }
}
