using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("shipping_rates")]
    public class ShippingRate
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("shipping_zone_id")]
        [ForeignKey("ShippingZone")]
        public int ShippingZoneId { get; set; }

        [Required]
        [Column("weight_unit")]
        [RegularExpression("^(g|kg)$")]
        public string WeightUnit { get; set; }

        [Column("min_value")]
        [Range(0, double.MaxValue)]
        public decimal MinValue { get; set; }

        [Column("max_value")]
        [Range(0, double.MaxValue)]
        public decimal? MaxValue { get; set; }

        [Column("no_max")]
        public bool NoMax { get; set; } = true;

        [Column("price")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        // Navigation property
        public virtual ShippingZone ShippingZone { get; set; }
    }
}
