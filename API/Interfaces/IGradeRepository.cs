using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IGradeRepository
    {
        Task<Grade> GetGrade(int id);
        Task<Grade> AddGrades(Grade grade);
        Task<IEnumerable<Grade>> GetGrades();
        Task<IEnumerable<Grade>> GetGradesWithAssignment(int assignmentId);

    }
}