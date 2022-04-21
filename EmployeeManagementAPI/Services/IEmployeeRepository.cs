using System.Collections.Generic;
using EmployeeManagementAPI.Entities;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        bool Save();
    }
}