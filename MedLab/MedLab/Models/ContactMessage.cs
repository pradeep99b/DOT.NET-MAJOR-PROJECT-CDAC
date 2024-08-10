using System;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{


    public class ContactMessage
    {
        [Key]
        public int MessageID { get; set; }  // Changed from Guid to int

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }

        [Required]
        public string? Message { get; set; }

        public DateTime? DateReceived { get; set; }

        public bool? IsResolved { get; set; }
    }

}
