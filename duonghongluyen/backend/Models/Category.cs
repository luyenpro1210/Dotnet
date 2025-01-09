using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("parent_id")]
        public Guid? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }

        [Required]
        [Column("category_name")]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [Column("category_description")]
        public string CategoryDescription { get; set; }

        [Column("icon")]
        public string Icon { get; set; } = null!;

        [Column("image")]
        public byte[] Image { get; set; }

        [Column("placeholder")]
        public int? Placeholder { get; set; }

        [Column("active")]
        public bool Active { get; set; } = true;

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [Column("created_by")]
        public Guid? CreatedById { get; set; }

        [Column("updated_by")]
        public Guid? UpdatedById { get; set; }

        // Navigation properties
        [ForeignKey("CreatedById")]
        public virtual StaffAccount CreatedBy { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual StaffAccount UpdatedBy { get; set; }

        // [Column("created_by")]
        // public Guid? CreatedById { get; set; }


        // [Column("updated_by")]
        // public Guid? UpdatedById { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
