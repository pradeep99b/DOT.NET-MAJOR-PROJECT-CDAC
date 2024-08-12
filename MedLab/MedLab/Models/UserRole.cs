using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string? RoleName { get; set; }

    }

}
