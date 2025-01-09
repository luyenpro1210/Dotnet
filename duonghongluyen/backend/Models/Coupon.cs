using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("coupons")]
    public class Coupon
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("code")]
        [MaxLength(50)]
        public string Code { get; set; }

        [Column("discount_value")]
        public decimal? DiscountValue { get; set; }

        [Required]
        [Column("discount_type")]
        [MaxLength(50)]
        public string DiscountType { get; set; }

        [Required]
        [Column("times_used")]
        public decimal TimesUsed { get; set; }

        [Column("max_usage")]
        public decimal? MaxUsage { get; set; }

        [Column("order_amount_limit")]
        public decimal? OrderAmountLimit { get; set; }

        [Column("coupon_start_date")]
        public DateTimeOffset? CouponStartDate { get; set; }

        [Column("coupon_end_date")]
        public DateTimeOffset? CouponEndDate { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [Column("created_by")]
        public Guid? CreatedById { get; set; }

        [Column("updated_by")]
        public Guid? UpdatedById { get; set; }

        // Navigation properties
        [ForeignKey("CreatedById")]
        public virtual StaffAccount CreatedBy { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual StaffAccount UpdatedBy { get; set; }

        public virtual ICollection<ProductCoupon> ProductCoupons { get; set; }



    }
}
