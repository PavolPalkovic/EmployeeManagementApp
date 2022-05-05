using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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



        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.Include(e => e.Position).ToListAsync();
        }
        public async Task<Employee> GetEmployee(int employeeId)
        {   
            return await _context.Employees.Include(e => e.Position).FirstOrDefaultAsync(e => e.Id == employeeId);
        }
        public async Task CreateEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }        
        public async Task DeleteEmployee(int employeeId)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
            }
        }     
        public async Task UpdateEmployee()
        {
            await _context.SaveChangesAsync();
        }
    }
}