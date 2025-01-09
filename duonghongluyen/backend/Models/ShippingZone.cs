using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("shipping_zones")] // Thay "your_table_name" bằng tên bảng của bạn
    public class ShippingZone // Thay "YourEntityName" bằng tên mà bạn muốn đặt cho entity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("display_name")]
        [MaxLength(255)]
        public string DisplayName { get; set; }

        [Column("active")]
        public bool Active { get; set; } = false;

        [Column("info")]
        public string Info { get; set; }

        [Column("free_shipping")]
        public bool FreeShipping { get; set; } = false;

        [Column("rate_type")]
        [MaxLength(64)]
        [RegularExpression("^(price|your_other_rate_type)$")] // Thay "your_other_rate_type" bằng loại rate khác nếu có
        public string RateType { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("created_by")]
        public Guid? CreatedById { get; set; }

        [Column("updated_by")]
        public Guid? UpdatedById { get; set; }

        // Navigation properties
        [ForeignKey("CreatedById")]
        public virtual StaffAccount CreatedBy { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual StaffAccount UpdatedBy { get; set; }


        public virtual ICollection<ShippingZoneCountry> ShippingZoneCountries { get; set; }

    }
}
