using evoWatch.Models;
using evoWatch.Models.DTO;
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

        [HttpPost]
        public IActionResult AddUser([FromBody]UserDTO user)
        {
            _userService.addUser(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _userService.getUsers();
            return Ok(result);
        }
    }
}
