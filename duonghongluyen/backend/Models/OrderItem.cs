using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("order_items")]
    public class OrderItem
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("product_id")]
        public Guid? ProductId { get; set; }

        // [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("order_id")]
        [MaxLength(50)]
        public string OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        // [Column("shipping_id")]
        // [ForeignKey("shippingId")]
        // public int shippingId { get; set; }
        // public Shipping Shipping { get; set; }

    }
}
