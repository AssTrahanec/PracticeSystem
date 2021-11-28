using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.MastersIntroductionPracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersIntroductionPracReportsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public MastersIntroductionPracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/MastersIntroductionPracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MastersIntroductionPracReportReadDto>>> GetAllMastersIntroductionPracReports()
        {
            return Ok(_mapper.Map<IEnumerable<MastersIntroductionPracReportReadDto>>(await _context.Pracbyops.ToListAsync()));
        }

        //GET api/MastersIntroductionPracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MastersIntroductionPracReportReadDto>> GetMastersIntroductionPracReportById(int id)
        {
            var report = await _context.Pracbyops.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<MastersIntroductionPracReportReadDto>(report));
            return NotFound();
        }

        //POST api/MastersIntroductionPracReports
        [HttpPost]
        public async Task<ActionResult<MastersIntroductionPracReportReadDto>> CreateMastersIntroductionPracReport(MastersIntroductionPracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbyop>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMastersIntroductionPracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/MastersIntroductionPracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMastersIntroductionPracReport(int id, MastersIntroductionPracReportUpdateDto reportUpdateDto)
        {
            var report = await _context.Pracbyops.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report == null)
                return NotFound();

            if (reportUpdateDto == null)
                return BadRequest();

            _mapper.Map(reportUpdateDto, report);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/MastersIntroductionPracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMastersIntroductionPracReport(int id)
        {
            var report = await _context.Pracbyops.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report == null)
                return NotFound();
            _context.Pracbyops.Remove(report);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}