using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("sells")]
    public class Sell
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        // [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
