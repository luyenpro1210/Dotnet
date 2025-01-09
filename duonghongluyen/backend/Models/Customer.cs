using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("first_name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [Column("email")]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("active")]
        public bool Active { get; set; } = true;

        [Column("registered_at")]
        public DateTimeOffset RegisteredAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
