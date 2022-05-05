using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementAPI.Entities;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeHistoryRepository
    {
        Task<IEnumerable<EmployeeHistory>> GetEmployeesHistory();
        Task<EmployeeHistory> GetEmployeeHistory(int employeeId);
        Task CreateEmployeeHistory(EmployeeHistory employee);
        Task DeleteEmployeeHistory(int employeeId);
    }
}