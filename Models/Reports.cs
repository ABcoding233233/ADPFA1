using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalityManagementSystem.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }

        [Required]
        public int CitizenID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Report Type")]
        public required string ReportType { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public required string Details { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Submission Date")]
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        [ForeignKey("CitizenID")]
        public required Citizen Citizen { get; set; }
    }
}