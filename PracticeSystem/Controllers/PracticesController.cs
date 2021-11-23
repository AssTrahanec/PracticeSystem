using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Data;
using PracticeSystem.Dtos.PracticeDto;
using PracticeSystem.Models;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticesController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public PracticesController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/Practices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracticeReadDto>>> GetAllPractices()
        {
            return Ok(_mapper.Map<IEnumerable<Practice>>(await _context.prac.ToListAsync()));
        }

        //GET api/Practices/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PracticeReadDto>> GetPracticeById(int id)
        {
            var practice = await _context.prac.FirstOrDefaultAsync(x => x.pracid == id);
            if (practice == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PracticeReadDto>(practice));
        }

        //POST api/Practices
        [HttpPost]
        public async Task<ActionResult<PracticeReadDto>> CreatePractice(PracticeCreateDto practiceCreateDto)
        {
            if (practiceCreateDto == null)
                return BadRequest();
            var practiceModel = _mapper.Map<Practice>(practiceCreateDto);
            await _context.prac.AddAsync(practiceModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPracticeById), new {id = practiceModel.pracid}, practiceModel);
        }

        //PUT api/Practices/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PracticeReadDto>> UpdatePractice(int id, PracticeUpdateDto practiceUpdateDto)
        {
            var practice = await _context.prac.FirstOrDefaultAsync(x => x.pracid == id);
            if (practice == null)
                return NotFound();
            if (practiceUpdateDto == null)
                return BadRequest();
            _mapper.Map(practiceUpdateDto, practice);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/Practices/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<PracticeReadDto>> DeletePractice(int id)
        {
            var practice = await _context.prac.FirstOrDefaultAsync(x => x.pracid == id);
            if (practice == null)
                return NotFound();
            _context.Remove(practice);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}