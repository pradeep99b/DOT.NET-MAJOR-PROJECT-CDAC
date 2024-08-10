using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
  

    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        public int? UserID { get; set; }

        [ForeignKey("UserID")]
        public User? User { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? PaymentDate { get; set; }

        [MaxLength(50)]
        public string? PaymentMethod { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [MaxLength(100)]
        public string? RazorpayPaymentId { get; set; }  // Store Razorpay Payment ID

        [MaxLength(100)]
        public string? RazorpayOrderId { get; set; }  // Store Razorpay Order ID

        [MaxLength(100)]
        public string? RazorpaySignature { get; set; }  // Store Razorpay Signature

        public bool? IsRefunded { get; set; }  // Track if payment was refunded
    }

}
