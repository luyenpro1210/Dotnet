using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("order_statuses")]
    public class OrderStatus
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column("status_name")]
        [MaxLength(255)]
        public string StatusName { get; set; }

        [Required]
        [Column("color")]
        [MaxLength(50)]
        public string Color { get; set; }

        [Column("privacy")]
        [MaxLength(10)]
        [RegularExpression("^(public|private)$")]
        public string Privacy { get; set; } = "private";

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedAt { get; set; }

        [Column("created_by")]
        public Guid? CreatedById { get; set; }

        [Column("updated_by")]
        public Guid? UpdatedById { get; set; }

        // Navigation properties
        [ForeignKey("CreatedById")]
        public virtual StaffAccount CreatedBy { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual StaffAccount UpdatedBy { get; set; }

    }
}
