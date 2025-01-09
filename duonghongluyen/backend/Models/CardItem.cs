using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("card_items")]
    public class CardItem
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("card_id")]
        public Guid? CardId { get; set; }

        [ForeignKey("CardId")]
        public virtual Card Card { get; set; }

        [Column("product_id")]
        public Guid? ProductId { get; set; }

        // [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("quantity")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;
    }
}
