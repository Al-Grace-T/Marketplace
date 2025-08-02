using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-user")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Dev version");
        }

        [HttpPost("create-user")]
        public IActionResult Create([FromBody] CreateUserDto dto)
        {
            CreateUserResultDto result = _userService.CreateUser(dto);
            return Ok(result);
        }

        [HttpPatch("update-user")]
        [Authorize]
        public IActionResult Update()
        {
            return Ok("Dev version");
        }

        [HttpDelete("delete-user")]
        [Authorize]
        public IActionResult Delete()
        {
            return Ok("Dev version");
        }
    }
}
