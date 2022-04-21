using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    // New DTO for creation, because user (in most cases) is not responsible for ID
    public class PositionForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}