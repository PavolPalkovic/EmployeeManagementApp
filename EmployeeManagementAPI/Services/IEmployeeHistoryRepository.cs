using System.Collections.Generic;
using EmployeeManagementAPI.Entities;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeHistoryRepository
    {
        IEnumerable<EmployeeHistory> GetEmployeesHistory();
        EmployeeHistory GetEmployeeHistory(int employeeId);
        void CreateEmployeeHistory(EmployeeHistory employee);
        void DeleteEmployeeHistory(EmployeeHistory employee);
        bool Save();
    }
}