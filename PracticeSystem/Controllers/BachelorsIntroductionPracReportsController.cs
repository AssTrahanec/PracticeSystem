using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.BachelorsIntroductionPracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BachelorsIntroductionPracReportsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public BachelorsIntroductionPracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/BachelorsIntroductionPracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BachelorsIntroductionPracReportReadDto>>> GetAllBachelorsIntroductionPracReports()
        {
            return Ok(_mapper.Map<IEnumerable<BachelorsIntroductionPracReportReadDto>>(await _context.Pracbyops.ToListAsync()));
        }

        //GET api/BachelorsIntroductionPracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BachelorsIntroductionPracReportReadDto>> GetBachelorsIntroductionPracReportById(int id)
        {
            var report = await _context.Pracbyops.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<BachelorsIntroductionPracReportReadDto>(report));
            return NotFound();
        }

        //POST api/BachelorsIntroductionPracReports
        [HttpPost]
        public async Task<ActionResult<BachelorsIntroductionPracReportReadDto>> CreateBachelorsIntroductionPracReport(BachelorsIntroductionPracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbyop>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBachelorsIntroductionPracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/BachelorsIntroductionPracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBachelorsIntroductionPracReport(int id, BachelorsIntroductionPracReportUpdateDto reportUpdateDto)
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

        //DELETE api/BachelorsIntroductionPracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBachelorsIntroductionPracReport(int id)
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