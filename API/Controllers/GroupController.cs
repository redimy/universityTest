using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class GroupController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        public GroupController(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GroupDto>> Post(GroupDto groupDto)
        {
            try
            {
                var group = _mapper.Map<Group>(groupDto);

                var newGroup = await _groupRepository.AddGroup(group);
                if (newGroup == null)
                {
                    return BadRequest();
                }
                var newGroupDto = _mapper.Map<Group>(groupDto);
                return CreatedAtAction(nameof(Post), new { id = newGroupDto.id, }, newGroupDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups()
        {
            var groups = await _groupRepository.GetGroups();

            var groupsToReturn = _mapper.Map<IEnumerable<GroupDto>>(groups);

            return Ok(groupsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetGroup(int id)
        {
            var group = await _groupRepository.GetGroup(id);

            return _mapper.Map<GroupDto>(group);
        }

        [HttpGet("groupsByUser/{id}")]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroupsByUser(int id)
        {

                var groups = await _groupRepository.GetUserWithGroups(id);
                if (groups == null)
                {
                    return NotFound();
                }
                var groupsToReturn = _mapper.Map<IEnumerable<GroupDto>>(groups);

                return Ok(groupsToReturn);
        }
    }
}