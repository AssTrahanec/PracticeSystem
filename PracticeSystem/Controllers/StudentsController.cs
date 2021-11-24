using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos;
using PracticeSystem.Dtos.Student;


namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public StudentsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetAllStudents()
        {
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(await _context.Studs.ToListAsync()));
        }

        //GET api/students/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDto>> GetStudentById(int id)
        {
            var student = await _context.Studs.FirstOrDefaultAsync(x => x.Sid == id);
            if (student != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(student));
            }

            return NotFound();
        }
        
        //GET api/students?grid={grid}
        [HttpGet("grid={grid}")]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetStudentByGroupId(int grid)
        {
            var students = await _context.Studs.Where(x => x.Grid == grid).ToListAsync();
            if (students != null)
            {
                return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
            }

            return NotFound();
        }
        //GET api/students?login={login}
        [HttpGet("login={login}")]
        public async Task<ActionResult<StudentReadDto>> GetStudentByLogin(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (user == null)
            {
                return NotFound();
            }
            var student = await _context.Studs.FirstOrDefaultAsync(x => x.Sid == user.Uid);
            if (student != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(student));
            }

            return NotFound();
        }
        //POST api/students
        [HttpPost]
        public async Task<ActionResult<StudentReadDto>> CreateStudent(StudentCreateDto studentCreateDto)
        {
            if (studentCreateDto == null)
            {
                return BadRequest();
            }

            var studentModel = _mapper.Map<Stud>(studentCreateDto);
            await _context.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudentById), new {id = studentModel.Sid}, studentModel);
        }

        //PUT api/students/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentReadDto>> UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var student = _context.Studs.FirstOrDefaultAsync(x => x.Sid == id);
            if (student == null)
                return NotFound();
            if (studentUpdateDto == null)
                return BadRequest();
            await _mapper.Map(studentUpdateDto, student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //DELETE api/students/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentReadDto>> DeleteStudent(int id)
        {
            var student = await _context.Studs.FirstOrDefaultAsync(x => x.Sid == id);
            if (student == null)
                return NotFound();
            _context.Studs.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}