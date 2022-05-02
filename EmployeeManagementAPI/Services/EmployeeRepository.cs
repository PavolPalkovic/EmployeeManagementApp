using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementAPI.Context;
using EmployeeManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.Include(e => e.Position).ToList();
        }
        public Employee GetEmployee(int employeeId)
        {   
            return _context.Employees.Include(e => e.Position).FirstOrDefault(e => e.Id == employeeId);
        }
        public void CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }        
        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
        }     
        public void UpdateEmployee(Employee employee)
        {
            
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}