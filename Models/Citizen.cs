using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class Citizen
    {
        [Key]
        public int CitizenID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}