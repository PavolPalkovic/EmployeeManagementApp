using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Entities
{
    public class EmployeeHistory
    {   
        [Key] //Key data annotation - convention for primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Generates primary keys
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public DateTime DateOfDeletion { get; set; }

        // Navigation Property
        // Employee has position
        [ForeignKey("Position")]
        [Required]
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
