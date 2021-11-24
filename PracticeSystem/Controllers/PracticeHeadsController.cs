using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.PracticeDto;
using PracticeSystem.Dtos.PracticeHeadsDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeHeadsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public PracticeHeadsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/PracticeHeads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracticeHeadReadDto>>> GetAllPracticeHeads()
        {
            return Ok(_mapper.Map<IEnumerable<PracticeHeadReadDto>>(await _context.Pheads.ToListAsync()));
        }

        //GET api/PracticeHeads/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PracticeHeadReadDto>> GetPracticeHeadById(int id)
        {
            var practiceHead = await _context.Pheads.FirstOrDefaultAsync(x => x.Pid == id);
            if (practiceHead == null)
                return NotFound();
            return Ok(_mapper.Map<PracticeHeadReadDto>(practiceHead));
        }

        //POST api/PracticeHeads
        [HttpPost]
        public async Task<ActionResult<PracticeReadDto>> CreatePracticeHead(PracticeHeadCreateDto practiceHeadCreateDto)
        {
            if (practiceHeadCreateDto == null)
                return BadRequest();
            var practiceHeadModel = _mapper.Map<Phead>(practiceHeadCreateDto);
            await _context.AddAsync(practiceHeadModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPracticeHeadById), new {id = practiceHeadModel.Pid}, practiceHeadModel);
        }

        //PUT api/PracticeHeads/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PracticeReadDto>> UpdatePracticeHead(int id,
            PracticeHeadUpdateDto practiceHeadUpdateDto)
        {
            var practiceHead = await _context.Pheads.FirstOrDefaultAsync(x => x.Pid == id);
            if (practiceHead == null)
                return NotFound();
            if (practiceHeadUpdateDto == null)
                return BadRequest();
            _mapper.Map(practiceHeadUpdateDto, practiceHead);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //DELETE api/PracticeHeads/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<PracticeReadDto>> DeletePracticeHead(int id)
        {
            var practiceHead = await _context.Pheads.FirstOrDefaultAsync(x => x.Pid == id);
            if (practiceHead == null)
                return NotFound();
            _context.Remove(practiceHead);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}