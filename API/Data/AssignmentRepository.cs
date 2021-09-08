using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly DataContext _context;
        public AssignmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
            }

            return assignment;
        }

        public async Task<Assignment> GetAssignment(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task<IEnumerable<Assignment>> GetAssignments()
        {
            return await _context.Assignments.Include(u => u.Group).ToListAsync();
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentWithGroups(int groupId)
        {
            return await _context.Assignments.Where(x => x.GroupId == groupId).ToListAsync();
        }
    }
}