using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.PostgradsInvestigationReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostgradsInvestigationReportsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public PostgradsInvestigationReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/PostgradsInvestigationReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostgradsInvestigationReportReadDto>>> GetAllPostgradsInvestigationReports()
        {
            return Ok(_mapper.Map<IEnumerable<PostgradsInvestigationReportReadDto>>(await _context.Pracbptps.ToListAsync()));
        }

        //GET api/PostgradsInvestigationReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostgradsInvestigationReportReadDto>> GetPostgradsInvestigationReportById(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<PostgradsInvestigationReportReadDto>(report));
            return NotFound();
        }

        //POST api/PostgradsInvestigationReports
        [HttpPost]
        public async Task<ActionResult<PostgradsInvestigationReportReadDto>> CreatePostgradsInvestigationReport(PostgradsInvestigationReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbptp>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostgradsInvestigationReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/PostgradsInvestigationReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePostgradsInvestigationReport(int id, PostgradsInvestigationReportUpdateDto reportUpdateDto)
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

        //DELETE api/PostgradsInvestigationReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostgradsInvestigationReport(int id)
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