using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    

    public class TestCategory
    {
        [Key]
        public int CategoryID { get; set; }  // Changed from Guid to int

        [Required, MaxLength(100)]
        public string? CategoryName { get; set; }

        public string? Description { get; set; }
    }

}
