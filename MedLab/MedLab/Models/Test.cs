using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    

    public class Test
    {
        [Key]
        public int TestID { get; set; }  // Changed from Guid to int

        [Required, MaxLength(200)]
        public string? TestName { get; set; }

        public string? Description { get; set; }

        public string? PreparationInstructions { get; set; }

        public decimal? Price { get; set; }

        public int? CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public TestCategory? Category { get; set; }

        public bool? IsActive { get; set; }
    }

}
