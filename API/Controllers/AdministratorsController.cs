using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministratorsController : ControllerBase
    {
        private readonly DataContext _context;
        public AdministratorsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministrators()
        {
            return await _context.Administrators.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Administrator>> GetAdministratorById(int id)
        {
            return await _context.Administrators.FindAsync(id);
        }
    }
}