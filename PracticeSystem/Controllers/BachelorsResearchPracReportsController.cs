using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.BachelorsResearchPracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BachelorsResearchPracReportsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public BachelorsResearchPracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/BachelorsResearchPracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BachelorsResearchPracReportReadDto>>> GetAllBachelorsResearchPracReports()
        {
            return Ok(_mapper.Map<IEnumerable<BachelorsResearchPracReportReadDto>>(await _context.Pracbptps.ToListAsync()));
        }

        //GET api/BachelorsResearchPracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BachelorsResearchPracReportReadDto>> GetBachelorsResearchPracReportById(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<BachelorsResearchPracReportReadDto>(report));
            return NotFound();
        }

        //POST api/BachelorsResearchPracReports
        [HttpPost]
        public async Task<ActionResult<BachelorsResearchPracReportReadDto>> CreateBachelorsResearchPracReport(BachelorsResearchPracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbptp>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBachelorsResearchPracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/BachelorsResearchPracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBachelorsResearchPracReport(int id, BachelorsResearchPracReportUpdateDto reportUpdateDto)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report == null)
                return NotFound();

            if (reportUpdateDto == null)
                return BadRequest();

            _mapper.Map(reportUpdateDto, report);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/BachelorsResearchPracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBachelorsResearchPracReport(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report == null)
                return NotFound();
            _context.Pracbptps.Remove(report);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}