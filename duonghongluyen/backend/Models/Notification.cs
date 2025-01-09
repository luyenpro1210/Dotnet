using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("notifications")]
    public class Notification
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("account_id")]
        public Guid? AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual StaffAccount Account { get; set; }

        [Column("title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("seen")]
        public bool Seen { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [Column("receive_time")]
        public DateTimeOffset? ReceiveTime { get; set; }

        [Column("notification_expiry_date")]
        public DateTime? NotificationExpiryDate { get; set; }
    }
}
