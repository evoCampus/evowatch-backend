using System.Net.Mime;
using evoWatch.DTOs;
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
        public async Task<IActionResult> AddUser([FromBody]UserDTO user)
        {
            await _userService.AddUserAsync(user);
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

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }
    }
}
