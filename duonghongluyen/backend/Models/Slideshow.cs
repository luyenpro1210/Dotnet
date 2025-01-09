using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace duonghongluyen.Exercise02.Models
{
    [Table("slideshows")]
    public class Slideshow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column("description_url")]
        public String descriptionUrl { get; set; }
        [Column("image_url")]
        public String imageUrl { get; set; }
        [Column("created_by")]
        public Guid? CreatedById { get; set; }

        [Column("updated_by")]
        public Guid? UpdatedById { get; set; }

        // Navigation properties
        [ForeignKey("CreatedById")]
        public virtual StaffAccount CreatedBy { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual StaffAccount UpdatedBy { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }



    }
}
