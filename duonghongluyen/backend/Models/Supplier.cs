using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("suppliers")]
    public class Supplier
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("supplier_name")]
        [MaxLength(255)]
        public string SupplierName { get; set; }

        [Column("company")]
        [MaxLength(255)]
        public string Company { get; set; }

        [Column("phone_number")]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("address_line1")]
        public string AddressLine1 { get; set; }

        [Column("address_line2")]
        public string AddressLine2 { get; set; }

        [Column("country_id")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Column("city")]
        [MaxLength(255)]
        public string City { get; set; }

        [Column("note")]
        public string Note { get; set; }

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


        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; }

    }
}
