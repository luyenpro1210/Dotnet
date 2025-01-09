using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("product_shippings_info")]
    public class ProductShipping
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }


        [Column("shipping_charge", TypeName = "numeric")]
        public decimal shippingCharge { get; set; }
        public bool free { get; set; }
        [Column("estimated_days", TypeName = "numeric")]
        public int estimatedDays { get; set; }


    }
}
