using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeDto 
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartingDate { get; set; }
        public double Salary { get; set; }
        public int PositionId { get; set; }
        public PositionDto Position { get; set; }
    }
}

