using System.Collections.Generic;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeDto 
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string PositionName { get; set; }
        public string StartingDate { get; set; }
        public double Salary { get; set; }
        //public ICollection<PreviousPosition> PreviousPositions { get; set; }
    }
}

