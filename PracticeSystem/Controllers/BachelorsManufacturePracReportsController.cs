using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.BachelorsManufacturePracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BachelorsManufacturePracReportsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public BachelorsManufacturePracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/BachelorsManufacturePracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BachelorsManufacturePracReportReadDto>>> GetAllBachelorsManufacturePracReports()
        {
            return Ok(_mapper.Map<IEnumerable<BachelorsManufacturePracReportReadDto>>(await _context.Pracbptps.ToListAsync()));
        }

        //GET api/BachelorsManufacturePracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BachelorsManufacturePracReportReadDto>> GetBachelorsManufacturePracReportById(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<BachelorsManufacturePracReportReadDto>(report));
            return NotFound();
        }

        //POST api/BachelorsManufacturePracReports
        [HttpPost]
        public async Task<ActionResult<BachelorsManufacturePracReportReadDto>> CreateBachelorsManufacturePracReport(BachelorsManufacturePracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbptp>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBachelorsManufacturePracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/BachelorsManufacturePracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBachelorsManufacturePracReport(int id, BachelorsManufacturePracReportUpdateDto reportUpdateDto)
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

        //DELETE api/BachelorsManufacturePracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBachelorsManufacturePracReport(int id)
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