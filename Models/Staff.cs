using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; } // Matches SSMS column name

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty; // Matches SSMS column name

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; } = string.Empty; // Matches SSMS column name

        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; } = string.Empty; // Matches SSMS column name

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty; // Matches SSMS column name

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty; // Matches SSMS column name

        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; } // Matches SSMS column name
    }
}