using System;
using System.Collections.Generic;
using EmployeeManagementAPI.Services;
using EmployeeManagementAPI.Context;
using EmployeeManagementAPI.Entities;
using System.Linq;

namespace EmployeeManagementAPI.Services
{
    public class PositionRepository : IPositionRepository
    {
        private readonly EmployeeDbContext _context;

        public PositionRepository(EmployeeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public IEnumerable<Position> GetPositions()
        {
            return _context.Positions.ToList();
        }
        public Position GetPosition(int positionId)
        {
            return _context.Positions.Where(p => p.Id == positionId).FirstOrDefault();
        }
        public void AddPosition(Position position)
        {
            _context.Positions.Add(position);
        }
        public void DeletePosition(Position position)
        {
            _context.Positions.Remove(position);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}