using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Data;
using PracticeSystem.Dtos;
using PracticeSystem.Models;

namespace PracticeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;

        private readonly PracticeSystemContext _context;

        public UsersController(IMapper mapper, PracticeSystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(await _context.users.ToListAsync()));
        }

        //GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUserById(int id)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.uid == id);
            if (user != null)
                return Ok(_mapper.Map<UserReadDto>(user));
            return NotFound();
        }

        //POST api/users
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateUser(UserCreateDto userCreateDto)
        {
            if (userCreateDto == null)
            {
                return BadRequest();
            }

            var userModel = _mapper.Map<User>(userCreateDto);
            await _context.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new {id = userModel.uid}, userModel);
        }

        //PUT api/users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.uid == id);
            if (user == null)
                return NotFound();

            if (userUpdateDto == null)
                return BadRequest();

            _mapper.Map(userUpdateDto, user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.uid == id);
            if (user == null)
                return NotFound();
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}