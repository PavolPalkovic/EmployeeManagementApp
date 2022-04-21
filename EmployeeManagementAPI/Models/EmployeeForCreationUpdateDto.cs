using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeForCreationUpdateDto
    {
        [Required(ErrorMessage = "You should provide a FirstName value.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should provide a LastName value.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "You should provide a DateOfBirth value.")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "You should provide a PositionName value.")]
        [MaxLength(20)]
        public string PositionName { get; set; }

        [Required(ErrorMessage = "You should provide a StartingDate value.")]
        public string StartingDate { get; set; }

        [Required(ErrorMessage = "You should provide a Salary value.")]
        public double Salary { get; set; }
    }
}