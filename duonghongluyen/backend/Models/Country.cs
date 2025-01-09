using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("countries")]
    public class Country
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("iso")]
        [MaxLength(2)]
        public string Iso { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [Column("upper_name")]
        [MaxLength(80)]
        public string UpperName { get; set; }

        [Column("iso3")]
        [MaxLength(3)]
        public string Iso3 { get; set; }

        [Column("num_code")]
        public short? NumCode { get; set; }

        [Required]
        [Column("phone_code")]
        public int PhoneCode { get; set; }

        public virtual ICollection<ShippingZoneCountry> ShippingZoneCountries { get; set; }

    }
}
