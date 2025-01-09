using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("staff_accounts")]
    public class StaffAccount
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("role_id")]

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("active")]
        public bool Active { get; set; } = true;

        [Column("image")]
        public string Image { get; set; }

        [Column("placeholder")]
        public string Placeholder { get; set; }

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

        // [Column("created_by")]
        // public Guid? CreatedBy { get; set; }

        // [Column("updated_by")]
        // public Guid? UpdatedBy { get; set; }

        // public virtual ICollection<StaffRole> StaffRoles { get; set; }

    }
}
