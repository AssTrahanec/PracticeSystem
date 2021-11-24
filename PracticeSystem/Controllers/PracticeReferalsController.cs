using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.PracticeReferalDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeReferalsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public PracticeReferalsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/PracticeReferals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracticeReferalReadDto>>> GetAllPracticeReferals()
        {
            return Ok(_mapper.Map<IEnumerable<PracticeReferalReadDto>>(await _context.Preferals.ToListAsync()));
        }

        //GET api/PracticeReferals/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PracticeReferalReadDto>> GetPracticeReferalById(int id)
        {
            var practiceReferal = await _context.Preferals.FirstOrDefaultAsync(x => x.Pracid == id);
            if (practiceReferal != null)
                return Ok(_mapper.Map<PracticeReferalReadDto>(practiceReferal));
            return NotFound();
        }

        //POST api/PracticeReferals
        [HttpPost]
        public async Task<ActionResult<PracticeReferalReadDto>> CreatePracticeReferal(PracticeReferalCreateDto practiceReferalCreateDto)
        {
            if (practiceReferalCreateDto == null)
            {
                return BadRequest();
            }

            var practiceReferalModel = _mapper.Map<Preferal>(practiceReferalCreateDto);
            await _context.AddAsync(practiceReferalModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPracticeReferalById), new {id = practiceReferalModel.Pracid}, practiceReferalModel);
        }

        //PUT api/PracticeReferals/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePracticeReferal(int id, PracticeReferalUpdateDto practiceReferalUpdateDto)
        {
            var practiceReferal = await _context.Preferals.FirstOrDefaultAsync(x => x.Pracid == id);
            if (practiceReferal == null)
                return NotFound();

            if (practiceReferalUpdateDto == null)
                return BadRequest();

            _mapper.Map(practiceReferalUpdateDto, practiceReferal);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/PracticeReferals/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePracticeReferal(int id)
        {
            var practiceReferal = await _context.Preferals.FirstOrDefaultAsync(x => x.Pracid == id);
            if (practiceReferal == null)
                return NotFound();
            _context.Preferals.Remove(practiceReferal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}