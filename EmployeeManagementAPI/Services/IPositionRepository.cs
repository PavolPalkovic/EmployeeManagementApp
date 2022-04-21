using System.Collections.Generic;
using EmployeeManagementAPI.Entities;

namespace EmployeeManagementAPI.Services
{
    public interface IPositionRepository
    {
        IEnumerable<Position> GetPositions();
        Position GetPosition(int employeeId);
        void AddPosition(Position position);
        void DeletePosition(Position position);
        bool Save();
    }
}