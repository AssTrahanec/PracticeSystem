using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.BachelorsPredegreePracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BachelorsPredegreePracReportsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public BachelorsPredegreePracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/BachelorsPredegreePracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BachelorsPredegreePracReportReadDto>>> GetAllBachelorsPredegreePracReports()
        {
            return Ok(_mapper.Map<IEnumerable<BachelorsPredegreePracReportReadDto>>(await _context.Pracbptps.ToListAsync()));
        }

        //GET api/BachelorsPredegreePracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BachelorsPredegreePracReportReadDto>> GetBachelorsPredegreePracReportById(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<BachelorsPredegreePracReportReadDto>(report));
            return NotFound();
        }

        //POST api/BachelorsPredegreePracReports
        [HttpPost]
        public async Task<ActionResult<BachelorsPredegreePracReportReadDto>> CreateBachelorsPredegreePracReport(BachelorsPredegreePracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbptp>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBachelorsPredegreePracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/BachelorsPredegreePracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBachelorsPredegreePracReport(int id, BachelorsPredegreePracReportUpdateDto reportUpdateDto)
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

        //DELETE api/BachelorsPredegreePracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBachelorsPredegreePracReport(int id)
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