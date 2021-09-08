using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class AssignmentController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentController(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<AssignmentDto>> Post(AssignmentDto assignmentDto)
        {
            try
            {
                var assignment = _mapper.Map<Assignment>(assignmentDto);

                var newAssignment = await _assignmentRepository.AddAssignment(assignment);
                if (newAssignment == null)
                {
                    return BadRequest();
                }
                var newAssignmentDto = _mapper.Map<Assignment>(assignmentDto);
                return CreatedAtAction(nameof(Post), new { id = newAssignmentDto.id, }, newAssignmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignments()
        {
            var assignments = await _assignmentRepository.GetAssignments();

            var assignmentsToReturn = _mapper.Map<IEnumerable<AssignmentDto>>(assignments);

            return Ok(assignmentsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> GetAssignment(int id)
        {
            var assignment = await _assignmentRepository.GetAssignment(id);

            return _mapper.Map<AssignmentDto>(assignment);
        }

        [HttpGet("assignmentsByGroup/{id}")]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignmentsByGroup(int id)
        {

            var assignments = await _assignmentRepository.GetAssignmentWithGroups(id);
            if (assignments == null)
            {
                return NotFound();
            }
            var assignmentsToReturn = _mapper.Map<IEnumerable<AssignmentDto>>(assignments);

            return Ok(assignmentsToReturn);
        }
    }
}