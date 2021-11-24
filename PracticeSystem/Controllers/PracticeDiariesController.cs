using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.PracticeDiaryDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeDiariesController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public PracticeDiariesController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/PracticeDiaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracticeDiaryReadDto>>> GetAllPracticeDiaries()
        {
            return Ok(_mapper.Map<IEnumerable<PracticeDiaryReadDto>>(await _context.Pds.ToListAsync()));
        }

        //GET api/PracticeDiaries/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PracticeDiaryReadDto>> GetPracticeDiaryById(int id)
        {
            var practiceDiary = await _context.Pds.FirstOrDefaultAsync(x => x.Pracid == id);
            if (practiceDiary != null)
                return Ok(_mapper.Map<PracticeDiaryReadDto>(practiceDiary));
            return NotFound();
        }

        //POST api/PracticeDiaries
        [HttpPost]
        public async Task<ActionResult<PracticeDiaryReadDto>> CreatePracticeDiary(PracticeDiaryCreateDto practiceDiaryCreateDto)
        {
            if (practiceDiaryCreateDto == null)
                return BadRequest();
            var practiceDiaryModel = _mapper.Map<Pd>(practiceDiaryCreateDto);
            await _context.Pds.AddAsync(practiceDiaryModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPracticeDiaryById), new {id = practiceDiaryModel.Pracid}, practiceDiaryModel);
        }

        //PUT api/PracticeDiaries/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PracticeDiaryReadDto>> UpdatePracticeDiary(int id, PracticeDiaryUpdateDto practiceDiaryUpdateDto)
        {
            var practiceDiary = await _context.Pds.FirstOrDefaultAsync(x => x.Pracid == id);
            if (practiceDiaryUpdateDto == null)
                return BadRequest();
            if (practiceDiary == null)
                return NotFound();
            _mapper.Map(practiceDiaryUpdateDto, practiceDiary);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/PracticeDiaries/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<PracticeDiaryReadDto>> DeletePracticeDiary(int id)
        {
            var practiceDiary = await _context.Pds.FirstOrDefaultAsync(x => x.Pracid == id);
            if (practiceDiary == null)
            {
                return NotFound();
            }

            _context.Pds.Remove(practiceDiary);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}