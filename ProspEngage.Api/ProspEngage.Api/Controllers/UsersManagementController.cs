using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProspEngage.Manager;
using ProspEngage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspEngage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [EnableCors("CorsPolicy")]
    public class UsersManagementController : ControllerBase
    {
        private readonly IUserManagementManager _userManagementManager;

        public UsersManagementController(IUserManagementManager userManagementManager)
        {
            _userManagementManager = userManagementManager;
        }

        // GET: api/UsersManagement
        [HttpGet("getUsers")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        //[ClientAuthorize]
        public async Task<ActionResult<IEnumerable<User>>> getUsers()
        {
            var users = await _userManagementManager.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/UsersManagement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userManagementManager.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(user);
        }

        // POST: api/UsersManagement
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data cannot be null.");
            }

            await _userManagementManager.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        // PUT: api/UsersManagement/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (user == null || id != user.UserId)
            {
                return BadRequest("User data is invalid.");
            }

            var existingUser = await _userManagementManager.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userManagementManager.UpdateUserAsync(user);
            return NoContent();
        }

        // DELETE: api/UsersManagement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _userManagementManager.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userManagementManager.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
