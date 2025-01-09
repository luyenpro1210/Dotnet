using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("galleries")]
    public class Gallery
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("product_id")]
        public Guid? ProductId { get; set; }

        // [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("image")]
        public byte[]? Image { get; set; }


        [Column("placeholder")]
        public string? Placeholder { get; set; }

        [Column("is_thumbnail")]
        public bool? IsThumbnail { get; set; } = false;

        [Column("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
