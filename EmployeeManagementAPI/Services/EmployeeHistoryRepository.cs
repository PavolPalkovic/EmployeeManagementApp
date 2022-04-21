using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagementAPI.Context;
using EmployeeManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeHistoryRepository : IEmployeeHistoryRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeHistoryRepository(EmployeeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public IEnumerable<EmployeeHistory> GetEmployeesHistory()
        {
            return _context.EmployeesHistory.ToList();
        }
        public EmployeeHistory GetEmployeeHistory(int employeeId)
        {   
            return _context.EmployeesHistory.Where(e => e.Id == employeeId).FirstOrDefault();
        }
        public void CreateEmployeeHistory(EmployeeHistory employee)
        {
            _context.EmployeesHistory.Add(employee);
        }        
        public void DeleteEmployeeHistory(EmployeeHistory employee)
        {
            _context.EmployeesHistory.Remove(employee);
        }     

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}