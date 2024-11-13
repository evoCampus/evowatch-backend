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
        [HttpDelete("{id}", Name = nameof(RemoveUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// <param name="id"></param>
        /// <response code="200">User found, user is returned in body</response>
        /// <response code="404">User with specified ID not found</response>
        [HttpGet("getuserbyid/{id}", Name = nameof(GetUserById))] 
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try 
            { 
                var result = await _userService.GetUserByIdAsync(id);
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
        /// <param name="email"></param>
        /// <response code="200">User found, user is returned in body</response>
        /// <response code="404">User with specified Email not found</response>
        [HttpGet("getuserbyemail/{email}", Name = nameof(GetUserByEmail))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try 
            { 
                var result = await _userService.GetUserByEmailAsync(email);
                return Ok(result);
            }
            catch (UserNotFoundException)
            {
                return Problem($"User with specified Email address of {email} not found", null, StatusCodes.Status404NotFound, "title", "type");
            }
        }

        /// <summary>
        /// Modify user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <response code="200">User was successfully modified</response>
        /// <response code="404">User with specified ID not found</response>
        [HttpPatch("{id}", Name = nameof(ModifyUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ModifyUser(Guid id, [FromBody]ModifyUserDTO user)
        {
            try 
            { 
                await _userService.ModifyUserAsync(id, user);
            }
            catch (UserNotFoundException)
            {
                return Problem("User with specified ID not found", null, StatusCodes.Status404NotFound, "title", "type");
            }

            return Ok();
        }

        /// <summary>
        /// Modify user's password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <response code="200">User's password was successfully modified</response>
        /// <response code="404">User with specified ID not found</response>
        [HttpPatch("password/{id}", Name = nameof(ModifyUserPassword))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ModifyUserPassword(Guid id, [FromHeader]string password)
        {
            try 
            { 
                await _userService.ModifyUserPasswordAsync(id, password);
            }
            catch (UserNotFoundException)
            {
                return Problem("User with specified ID not found", null, StatusCodes.Status404NotFound, "title", "type");
            }

            return Ok();
        }

        /// <summary>
        /// List all users
        /// </summary>
        /// <response code="200"></response>
        [HttpGet(Name = nameof(GetUsers))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }
    }
}
