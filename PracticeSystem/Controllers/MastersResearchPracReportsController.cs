using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.MastersResearchPracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersResearchPracReportsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public MastersResearchPracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/MastersResearchPracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MastersResearchPracReportReadDto>>> GetAllMastersResearchPracReports()
        {
            return Ok(_mapper.Map<IEnumerable<MastersResearchPracReportReadDto>>(await _context.Pracbptps.ToListAsync()));
        }

        //GET api/MastersResearchPracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MastersResearchPracReportReadDto>> GetMastersResearchPracReportById(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<MastersResearchPracReportReadDto>(report));
            return NotFound();
        }

        //POST api/MastersResearchPracReports
        [HttpPost]
        public async Task<ActionResult<MastersResearchPracReportReadDto>> CreateMastersResearchPracReport(MastersResearchPracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbptp>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMastersResearchPracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/MastersResearchPracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMastersResearchPracReport(int id, MastersResearchPracReportUpdateDto reportUpdateDto)
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

        //DELETE api/MastersResearchPracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMastersResearchPracReport(int id)
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