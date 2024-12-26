using Microsoft.AspNetCore.Mvc;
using ProspEngage.Manager;
using ProspEngage.Models;
using System.Collections.Generic;

namespace ProspEngageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            return Ok(_userManager.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _userManager.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO user)
        {
            var createdUser = _userManager.CreateUser(user);
            return CreatedAtAction(nameof(Get), new { id = createdUser.ID }, createdUser);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDTO user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }
            _userManager.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userManager.DeleteUser(id);
            return NoContent();
        }
    }
}
