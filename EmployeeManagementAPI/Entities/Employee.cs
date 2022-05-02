using System;
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
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public double Salary { get; set; }

        // Navigation Property
        // Employee has position
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
