using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{


    public class TestBooking
    {
        [Key]
        public int BookingID { get; set; }  // Changed from Guid to int

        public int? UserID { get; set; }  // Changed from Guid to int

        [ForeignKey("UserID")]
        public User? User { get; set; }

        public int? TestID { get; set; }  // Changed from Guid to int

        [ForeignKey("TestID")]
        public Test? Test { get; set; }

        public DateTime? BookingDate { get; set; }
        public DateTime? AppointmentDate { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        public int? LabAssistantID { get; set; }  // Changed from Guid to int

        [ForeignKey("LabAssistantID")]
        public User? LabAssistant { get; set; }

        public string? Notes { get; set; }
    }

}
