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
        private readonly IProfilePictureService _profilePictureService;

        public UserController(IUserService userService,IProfilePictureService profilePictureService)
        {
            _userService = userService;
            _profilePictureService = profilePictureService;
        }

        /// <summary> 
        /// Registers user
        /// </summary>
        /// <param name="user">User to register</param>
        /// <response code="200">User was successfully registered</response>
        [HttpPost(Name = nameof(AddUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO user)
        {
            var result = await _userService.AddUserAsync(user);
            return Ok(result);
        }

        /// <summary>
        /// Deletes user 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <response code="200">User was successfully removed</response>
        /// <response code="404">User with specified ID not found</response>
        /// <response code="400">Couldn't delete the user with the specified ID</response>
        [HttpDelete("{id}", Name = nameof(RemoveUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveUser(Guid id, [FromHeader] string password)
        {
            try
            {
                if(!await _userService.RemoveUserAsync(id, password))
                {
                    return Problem($"Couldn't delete the user with the specified ID: {id}", null, StatusCodes.Status400BadRequest);
                }
            }
            catch (UserNotFoundException)
            {
                return Problem($"User with specified ID: {id} not found", null, StatusCodes.Status404NotFound);
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
        [HttpGet("{id:Guid}", Name = nameof(GetUserById))] 
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try 
            { 
                var result = await _userService.GetUserByIdAsync(id);
                return Ok(result);
            }
            catch (UserNotFoundException)
            {
                return Problem($"User with specified ID: {id} not found", null, StatusCodes.Status404NotFound);
            }
        }

        /// <summary>
        /// Gets user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <response code="200">User found, user is returned in body</response>
        /// <response code="404">User with specified Email not found</response>
        [HttpGet("{email}", Name = nameof(GetUserByEmail))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try 
            { 
                var result = await _userService.GetUserByEmailAsync(email);
                return Ok(result);
            }
            catch (UserNotFoundException)
            {
                return Problem($"User with specified Email address of {email} not found", null, StatusCodes.Status404NotFound);
            }
        }

        /// <summary>
        /// Modify user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <response code="200">User was successfully modified</response>
        /// <response code="404">User with specified ID not found</response>
        [HttpPut("{id}", Name = nameof(ModifyUser))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ModifyUser(Guid id, [FromBody] ModifyUserDTO user, [FromHeader] string password)
        {
            try
            { 
                var result = await _userService.ModifyUserAsync(id, user, password);
                return Ok(result);
            }
            catch (UserNotFoundException)
            {
                return Problem($"User with specified ID: {id} not found", null, StatusCodes.Status404NotFound);
            }
        }

        /// <summary>
        /// List all users
        /// </summary>
        /// <response code="200"></response>
        [HttpGet(Name = nameof(GetUsers))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }

        [HttpPut("profile-picture/{id:Guid}", Name = nameof(ModifyUserProfilePicture))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ModifyUserProfilePicture([FromForm] ProfilePictureFormDTO profile)
        {
            try
            {
                var result = await _userService.ModifyUserProfilePictureAsync(profile.userId, profile.file.OpenReadStream());
                return Ok(result);
            }
            catch (UserNotFoundException)
            {
                return Problem($"User with specified ID: {profile.userId} not found", null, StatusCodes.Status404NotFound);
            }
        }

    }
}
