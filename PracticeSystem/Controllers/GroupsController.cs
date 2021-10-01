using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Data;
using PracticeSystem.Dtos.Group;
using PracticeSystem.Models;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public GroupsController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupReadDto>>> GetAllGroups()
        {
            return Ok(_mapper.Map<IEnumerable<GroupReadDto>>(await _context.groupp.ToListAsync()));
        }

        //GET api/Groups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupReadDto>> GetGroupById(int id)
        {
            var group = await _context.groupp.FirstOrDefaultAsync(x => x.grid == id);
            if (group != null)
                return Ok(_mapper.Map<GroupReadDto>(group));
            return NotFound();
        }

        //POST api/Groups
        [HttpPost]
        public async Task<ActionResult<GroupReadDto>> CreateGroup(GroupCreateDto groupCreateDto)
        {
            if (groupCreateDto == null)
                return BadRequest();
            var groupModel = _mapper.Map<Group>(groupCreateDto);
            await _context.groupp.AddAsync(groupModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGroupById), new {id = groupModel.grid}, groupModel);
        }

        //PUT api/Groups/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<GroupReadDto>> UpdateGroup(int id, GroupUpdateDto groupUpdateDto)
        {
            var group = await _context.groupp.FirstOrDefaultAsync(x => x.grid == id);
            if (groupUpdateDto == null)
                return BadRequest();
            if (group == null)
                return NotFound();
            _mapper.Map(groupUpdateDto, group);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/Groups/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupReadDto>> DeleteGroup(int id)
        {
            var group = await _context.groupp.FirstOrDefaultAsync(x => x.grid == id);
            if (group == null)
            {
                return NotFound();
            }

            _context.groupp.Remove(group);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}