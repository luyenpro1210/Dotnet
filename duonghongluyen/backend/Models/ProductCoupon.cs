using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("product_coupons")]
    public class ProductCoupon
    {

        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }

        // [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        [Column("coupon_id")]
        public Guid CouponId { get; set; }

        [ForeignKey("CouponId")]
        public virtual Coupon Coupon { get; set; }
    }
}
