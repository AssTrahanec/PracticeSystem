using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos.MastersManufacturePracReportDto;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersManufacturePracReportsController : Controller
    {
         private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public MastersManufacturePracReportsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/MastersManufacturePracReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MastersManufacturePracReportReadDto>>> GetAllMastersManufacturePracReports()
        {
            return Ok(_mapper.Map<IEnumerable<MastersManufacturePracReportReadDto>>(await _context.Pracbptps.ToListAsync()));
        }

        //GET api/MastersManufacturePracReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MastersManufacturePracReportReadDto>> GetMastersManufacturePracReportById(int id)
        {
            var report = await _context.Pracbptps.FirstOrDefaultAsync(x => x.Pracid == id);
            if (report != null)
                return Ok(_mapper.Map<MastersManufacturePracReportReadDto>(report));
            return NotFound();
        }

        //POST api/MastersManufacturePracReports
        [HttpPost]
        public async Task<ActionResult<MastersManufacturePracReportReadDto>> CreateMastersManufacturePracReport(MastersManufacturePracReportCreateDto reportCreateDto)
        {
            if (reportCreateDto == null)
            {
                return BadRequest();
            }

            var reportModel = _mapper.Map<Pracbptp>(reportCreateDto);
            await _context.AddAsync(reportModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMastersManufacturePracReportById), new {id = reportModel.Pracid}, reportModel);
        }

        //PUT api/MastersManufacturePracReports/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMastersManufacturePracReport(int id, MastersManufacturePracReportUpdateDto reportUpdateDto)
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

        //DELETE api/MastersManufacturePracReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMastersManufacturePracReport(int id)
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