using System.Net.Mime;
using evoWatch.DTOs;
using evoWatch.Exceptions;
using evoWatch.Services;
using Microsoft.AspNetCore.Mvc;

namespace evoWatch.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary> 
        /// Registers user
        /// </summary>
        /// <param name="user">User to register</param>
        /// <response code="200">User was succesfully registered</response>
        [HttpPost(Name = nameof(AddUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser([FromBody]AddUserDTO user)
        {
            await _userService.AddUserAsync(user);
            return Ok();
        }

        /// <summary>
        /// Deletes user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(Guid id, [FromHeader]string password)
        {
            try
            {
                await _userService.RemoveUserAsync(id, password);
            }
            catch (UserNotFoundException)
            {
                return Problem("User with specified ID not found", null, StatusCodes.Status404NotFound, "title", "type");
            }
            catch (WrongPasswordException)
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetUserById([FromQuery]Guid Id)
        {
            var result = await _userService.GetUserByIdAsync(Id);
            return Ok(result);
        }

        [HttpGet]
        [Route("email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery]string Email)
        {
            var result = await _userService.GetUserByEmailAsync(Email);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> ModifyUser([FromQuery]Guid Id, [FromBody]ModifyUserDTO user)
        {
            try 
            { 
                await _userService.ModifyUserAsync(Id, user);
            }
            catch (UserNotFoundException)
            {
                return Problem("User with specified ID not found", null, StatusCodes.Status404NotFound, "title", "type");
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }
    }
}
