using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.PostgradsTeachingPracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostgradsTeachingPracReportsController : Controller
    {
       private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public PostgradsTeachingPracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/PostgradsTeachingPracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostgradsTeachingPracReportReadDto>>> GetAllPostgradsTeachingPracReports()
        {
            return Ok(_mapper.Map<IEnumerable<PostgradsTeachingPracReportReadDto>>(await _context.Pracbptps.ToListAsync()));
        }

        //GET api/PostgradsTeachingPracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PostgradsTeachingPracReportReadDto>> GetPostgradsTeachingPracReportById(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<PostgradsTeachingPracReportReadDto>(report));
            return NotFound();
        }

        //POST api/PostgradsTeachingPracReports
        [HttpPost]
        public async Task<ActionResult<PostgradsTeachingPracReportReadDto>> CreatePostgradsTeachingPracReport(PostgradsTeachingPracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbptp>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostgradsTeachingPracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/PostgradsTeachingPracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePostgradsTeachingPracReport(int id, PostgradsTeachingPracReportUpdateDto reportUpdateDto)
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

        //DELETE api/PostgradsTeachingPracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostgradsTeachingPracReport(int id)
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