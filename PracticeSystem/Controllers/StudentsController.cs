using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Data;
using PracticeSystem.Dtos;
using PracticeSystem.Dtos.Student;
using PracticeSystem.Models;


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
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(await _context.stud.ToListAsync()));
        }

        //GET api/students/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDto>> GetStudentById(int id)
        {
            var student = await _context.stud.FirstOrDefaultAsync(x => x.sid == id);
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

            var studentModel = _mapper.Map<Student>(studentCreateDto);
            await _context.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudentById), new {id = studentModel.sid}, studentModel);
        }

        //PUT api/students/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentReadDto>> UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var student = _context.stud.FirstOrDefaultAsync(x => x.sid == id);
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
            var student = await _context.stud.FirstOrDefaultAsync(x => x.sid == id);
            if (student == null)
                return NotFound();
            _context.stud.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}