using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group> GetGroup(int id); 
        Task<Group> AddGroup(Group group); 
        Task<IEnumerable<Group>> GetUserWithGroups(int userId);
        Task<IEnumerable<Group>> GetGroups();

    }
}