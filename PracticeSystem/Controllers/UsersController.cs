using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeSystem.Dtos;

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

        //GET api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsers()
        {
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(await _context.Users.ToListAsync()));
        }

        //GET api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Uid == id);
            if (user != null)
                return Ok(_mapper.Map<UserReadDto>(user));
            return NotFound();
        }

        //POST api/Users
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
            return CreatedAtAction(nameof(GetUserById), new {id = userModel.Uid}, userModel);
        }

        //PUT api/Users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Uid == id);
            if (user == null)
                return NotFound();

            if (userUpdateDto == null)
                return BadRequest();

            _mapper.Map(userUpdateDto, user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Uid == id);
            if (user == null)
                return NotFound();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}