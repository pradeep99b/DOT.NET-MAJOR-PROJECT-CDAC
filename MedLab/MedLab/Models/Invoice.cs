using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    

    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }  // Changed from Guid to int

        public int? UserID { get; set; }  // Changed from Guid to int

        [ForeignKey("UserID")]
        public User? User { get; set; }

        public int? BookingID { get; set; }  // Changed from Guid to int

        [ForeignKey("BookingID")]
        public TestBooking? TestBooking { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }
    }

}
