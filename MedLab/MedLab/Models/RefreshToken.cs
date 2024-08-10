using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
  

    public class RefreshToken
    {
        [Key]
        public int TokenID { get; set; }

        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public User? User { get; set; }

        public string? Token { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool? IsRevoked { get; set; }
    }

}
