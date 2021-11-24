using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos;

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
            if (await _context.Pheads.FirstOrDefaultAsync(x => x.Pid == id) == null)
                return NotFound();
            var practice = await _context.Pracs.FirstOrDefaultAsync(x => x.Pid == id);
            if (practice == null)
                return NotFound();
            var students = await _context.Studs.Where(x => x.Grid == practice.Grid).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }
    }
}