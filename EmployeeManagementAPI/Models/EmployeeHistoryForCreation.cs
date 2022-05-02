using System;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeHistoryForCreationDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PositionId { get; set; }
        public DateTime StartingDate { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfDeletion { get; set; }
    }
}