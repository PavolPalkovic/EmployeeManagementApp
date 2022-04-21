using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Entities
{
    public class Employee
    {   
        [Key] //Key data annotation - convention for primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Generates primary keys
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        [MaxLength(20)]
        public string PositionName { get; set; }
        
        [Required]
        public string StartingDate { get; set; }

        [Required]
        public double Salary { get; set; }
    }
}
