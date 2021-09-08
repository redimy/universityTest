using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GradeRepository : IGradeRepository
    {
        private readonly DataContext _context;
        public GradeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Grade> AddGrades(Grade grade)
        {
            _context.Grades.Add(grade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
            }

            return grade;
        }

        public async Task<Grade> GetGrade(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task<IEnumerable<Grade>> GetGrades()
        {
            return await _context.Grades.Include(u => u.assignment).ToListAsync();
        }

        public async Task<IEnumerable<Grade>> GetGradesWithAssignment(int assignmentId)
        {
            return await _context.Grades.Where(x => x.assignmentId == assignmentId).ToListAsync();
        }
    }
}