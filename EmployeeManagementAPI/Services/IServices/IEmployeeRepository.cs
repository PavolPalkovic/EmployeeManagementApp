using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementAPI.Entities;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task CreateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task UpdateEmployee();
    }
}