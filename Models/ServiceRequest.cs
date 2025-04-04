using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestID { get; set; } // Matches SSMS column name

        [Display(Name = "Citizen ID")]
        [Required(ErrorMessage = "Citizen ID is required.")]
        public int CitizenID { get; set; } // Matches SSMS column name

        [Required]
        [Display(Name = "Service Type")]
        public string ServiceType { get; set; } = string.Empty; // Matches SSMS column name

        [Display(Name = "Request Date")]
        public DateTime RequestDate { get; set; } = DateTime.Now; // Matches SSMS column name

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; } = string.Empty; // Matches SSMS column name
    }
}