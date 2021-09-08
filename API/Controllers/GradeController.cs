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
    public class GradeController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGradeRepository _gradeRepository;
        public GradeController(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GradeDto>> Post(GradeDto gradeDto)
        {
            try
            {
                var grade = _mapper.Map<Grade>(gradeDto);

                var newGrade = await _gradeRepository.AddGrades(grade);
                if (newGrade == null)
                {
                    return BadRequest();
                }
                var newGradeDto = _mapper.Map<Grade>(gradeDto);
                return CreatedAtAction(nameof(Post), new { id = newGradeDto.id, }, newGradeDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetAssignments()
        {
            var grades = await _gradeRepository.GetGrades();

            var gradesToReturn = _mapper.Map<IEnumerable<GradeDto>>(grades);

            return Ok(gradesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>> GetAssignment(int id)
        {
            var grade = await _gradeRepository.GetGrade(id);

            return _mapper.Map<GradeDto>(grade);
        }

        [HttpGet("gradesByAssignment/{id}")]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetGradesWithAssignment(int id)
        {

            var grades = await _gradeRepository.GetGradesWithAssignment(id);
            if (grades == null)
            {
                return NotFound();
            }
            var gradesToReturn = _mapper.Map<IEnumerable<GradeDto>>(grades);

            return Ok(gradesToReturn);
        }
    }
}