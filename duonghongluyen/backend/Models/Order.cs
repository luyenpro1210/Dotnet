using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        [MaxLength(50)]
        public string Id { get; set; }

        [Column("coupon_id")]
        public Guid? CouponId { get; set; }

        [ForeignKey("CouponId")]
        public virtual Coupon Coupon { get; set; }

        [Column("customer_id")]
        public Guid? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [Column("order_status_id")]
        public Guid? OrderStatusId { get; set; }

        [ForeignKey("OrderStatusId")]
        public virtual OrderStatus OrderStatus { get; set; }

        [Column("order_approved_at")]
        public DateTimeOffset? OrderApprovedAt { get; set; }

        [Column("order_delivered_carrier_date")]
        public DateTimeOffset? OrderDeliveredCarrierDate { get; set; }

        [Column("order_delivered_customer_date")]
        public DateTimeOffset? OrderDeliveredCustomerDate { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }


        [Column("updated_by")]
        public Guid? UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual StaffAccount UpdatedBy { get; set; }


    }
}
