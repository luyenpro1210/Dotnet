using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("customer_addresses")]
    public class CustomerAddress
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Required]
        [Column("address_line1")]
        public string AddressLine1 { get; set; }

        [Column("address_line2")]
        public string AddressLine2 { get; set; }

        [Required]
        [Column("phone_number")]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("dial_code")]
        [MaxLength(100)]
        public string DialCode { get; set; }

        [Required]
        [Column("country")]
        [MaxLength(255)]
        public string Country { get; set; }

        [Required]
        [Column("postal_code")]
        [MaxLength(255)]
        public string PostalCode { get; set; }

        [Required]
        [Column("city")]
        [MaxLength(255)]
        public string City { get; set; }
    }
}
