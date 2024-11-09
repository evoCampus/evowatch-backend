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
        /// <response code="200">User was successfully registered</response>
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
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <response code="200">User was successfully removed</response>
        /// <response code="404">User with specified ID not found</response>
        /// <response code="401">Wrong password</response>
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

        /// <summary>
        /// Gets user by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <response code="200">User found, user is returned in body</response>
        /// <response code="404">User with specified ID not found</response>
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetUserById([FromQuery]Guid Id)
        {
            try 
            { 
                var result = await _userService.GetUserByIdAsync(Id);
                return Ok(result);
            }
            catch (UserNotFoundException)
            {
                return Problem("User with specified ID not found", null, StatusCodes.Status404NotFound, "title", "type");
            }
        }

        /// <summary>
        /// Gets user by Email
        /// </summary>
        /// <param name="Email"></param>
        /// <response code="200">User found, user is returned in body</response>
        /// <response code="404">User with specified Email not found</response>
        [HttpGet]
        [Route("email")]
        public async Task<IActionResult> GetUserByEmail([FromQuery]string Email)
        {
            try 
            { 
                var result = await _userService.GetUserByEmailAsync(Email);
                return Ok(result);
            }
            catch (InvalidOperationException)
            {
                return Problem("User with specified Email not found", null, StatusCodes.Status404NotFound, "title", "type");
            }
        }

        /// <summary>
        /// Modify user
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="user"></param>
        /// <response code="200">User was successfully modified</response>
        /// <response code="404">User with specified ID not found</response>
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
