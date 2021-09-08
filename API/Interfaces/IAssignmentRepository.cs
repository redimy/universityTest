using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<Assignment> GetAssignment(int id); 
        Task<Assignment> AddAssignment(Assignment assignment); 
        Task<IEnumerable<Assignment>> GetAssignments();
        Task<IEnumerable<Assignment>> GetAssignmentWithGroups(int groupId);

    }
}