using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("product_tags")]
    public class ProductTag
    {
        [Column("tag_id")]
        public Guid TagId { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }

        [Column("product_id")]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


    }
}
