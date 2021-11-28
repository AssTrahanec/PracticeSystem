using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.PostgradsResearchPracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostgradsResearchPracReportsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public PostgradsResearchPracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/PostgradsResearchPracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostgradsResearchPracReportReadDto>>> GetAllPostgradsResearchPracReports()
        {
            return Ok(_mapper.Map<IEnumerable<PostgradsResearchPracReportReadDto>>(await _context.Pracbptps.ToListAsync()));
        }

        //GET api/PostgradsResearchPracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostgradsResearchPracReportReadDto>> GetPostgradsResearchPracReportById(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<PostgradsResearchPracReportReadDto>(report));
            return NotFound();
        }

        //POST api/PostgradsResearchPracReports
        [HttpPost]
        public async Task<ActionResult<PostgradsResearchPracReportReadDto>> CreatePostgradsResearchPracReport(PostgradsResearchPracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbptp>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostgradsResearchPracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/PostgradsResearchPracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePostgradsResearchPracReport(int id, PostgradsResearchPracReportUpdateDto reportUpdateDto)
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

        //DELETE api/PostgradsResearchPracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostgradsResearchPracReport(int id)
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