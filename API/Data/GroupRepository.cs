using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;
        public GroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Group> AddGroup(Group group)
        {
            _context.Groups.Add(group);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
            }

            return group;
        }

        public async Task<Group> GetGroup(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
            /* var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            var groups = _context.Groups.AsQueryable();

            groups = groups.Where(u => u.AppUserId == userId );
            users = groups.Select(u => u.AppUser);

            return await users.Select(user => new GroupDto
            {
                id = user.Id,
                UserName = user.UserName
            }).ToListAsync(); */

            return await _context.Groups.Include(u => u.AppUser).ToListAsync();

        }

        public async Task<IEnumerable<Group>> GetUserWithGroups(int userId)
        {
            return await _context.Groups.Where(x => x.AppUserId == userId).ToListAsync();
        }
    }
}