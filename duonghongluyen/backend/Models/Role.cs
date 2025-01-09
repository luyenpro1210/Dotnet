using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [StringLength(255)]
        [Column("role_name")]
        public string RoleName { get; set; }

        [StringLength(1024)]
        [Column("privileges")]
        public string Privileges { get; set; }
        // public virtual ICollection<StaffRole> StaffRoles { get; set; }
    }
}
