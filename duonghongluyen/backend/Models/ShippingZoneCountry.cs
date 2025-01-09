using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("shipping_country_zones")] // Tên bảng trung gian
    public class ShippingZoneCountry
    {
        [Key]
        public Guid Id { get; set; }

        [Column("shipping_zone_id")]
        [ForeignKey("ShippingZone")]
        public int ShippingZoneId { get; set; }
        public virtual ShippingZone ShippingZone { get; set; }

        [Column("country_id")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
