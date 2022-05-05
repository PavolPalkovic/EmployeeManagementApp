using System;
using System.Collections.Generic;
using EmployeeManagementAPI.Services;
using EmployeeManagementAPI.Context;
using EmployeeManagementAPI.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Services
{
    public class PositionRepository : IPositionRepository
    {
        private readonly EmployeeDbContext _context;

        public PositionRepository(EmployeeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await _context.Positions.ToListAsync();
        }
        public async Task<Position> GetPosition(int positionId)
        {
            return await _context.Positions.FirstOrDefaultAsync(p => p.Id == positionId);
        }
        public async Task CreatePosition(Position position)
        {
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePosition(int positionId)
        {
            var result = await _context.Positions.FirstOrDefaultAsync(p => p.Id == positionId);
            
            if (result != null)
            {
                _context.Positions.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}