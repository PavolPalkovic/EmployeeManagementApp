using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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



        public async Task<IEnumerable<EmployeeHistory>> GetEmployeesHistory()
        {
            return await _context.EmployeesHistory.Include(e => e.Position).ToListAsync();
        }
        public async Task<EmployeeHistory> GetEmployeeHistory(int employeeId)
        {   
            return await _context.EmployeesHistory.Include(e => e.Position).FirstOrDefaultAsync(e => e.Id == employeeId);
        }
        public async Task CreateEmployeeHistory(EmployeeHistory employee)
        {
            await _context.EmployeesHistory.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployeeHistory(int employeeId)
        {
            var result = await _context.EmployeesHistory.FirstOrDefaultAsync(e => e.Id == employeeId);
            
            if (result != null)
            {
                _context.EmployeesHistory.Remove(result);
                await _context.SaveChangesAsync();
            }
        }     
    }
}