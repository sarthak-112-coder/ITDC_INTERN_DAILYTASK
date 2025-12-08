using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Annotations.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Employee
    {
        [Required(ErrorMessage = "ID is Mandatory!!!")]
        [DisplayName("ID : ")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is Mandatory!!!")]
        [DisplayName("Name :")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name should be between 5 to 20 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is Mandatory!!!")]
        [DisplayName("Age :")]
        [Range(20, 60, ErrorMessage = "Age should be between 20 to 60")]
        public int? EmployeeAge { get; set; }

        [Required(ErrorMessage = "Gender is Mandatory!!!")]
        [DisplayName("Gender : ")]
        public string EmployeeGender { get; set; }

        [Required(ErrorMessage = "Email is Mandatory!!!")]
        [DisplayName("Email : ")]
        [RegularExpression(
            @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
            ErrorMessage = "Please Enter a Valid Email!"
        )]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DisplayName("Password : ")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Please Enter a Strong Password (Min 8 chars, 1 uppercase, 1 lowercase, 1 number, 1 special char)"
        )]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [DisplayName("Confirm Password : ")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConPassword { get; set; }

        [DisplayName("Organization Name :")]
        [ReadOnly(true)]
        public string OrganizationName { get; set; } 
    }
}
