
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{

    public class User : IdentityUser
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }

        // No need to redefine Email and PasswordHash since they're already in IdentityUser
        [MaxLength(15)]
        public string? Phone { get; set; }

        public string? Address { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? IsActive { get; set; }
    }

}

public enum UserRole
{
    ADMIN=1,
    PATIENT,
    LABASSISTANT
}
