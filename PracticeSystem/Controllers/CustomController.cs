using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Data;
using PracticeSystem.Dtos;
using PracticeSystem.Models;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : Controller
    {
        private readonly PracticeSystemContext _context;
        private readonly IMapper _mapper;

        public CustomController(PracticeSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetStudentByHeadId(int id)
        {
            if (await _context.phead.FirstOrDefaultAsync(x => x.pid == id) == null)
                return NotFound();
            var practice = await _context.prac.FirstOrDefaultAsync(x => x.pid == id);
            if (practice == null)
                return NotFound();
            var students = await _context.stud.Where(x => x.grid == practice.grid).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }
    }
}