using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementAPI.Entities;

namespace EmployeeManagementAPI.Services
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetPositions();
        Task<Position> GetPosition(int positionId);
        Task CreatePosition(Position position);
        Task DeletePosition(int positionId);
    }
}