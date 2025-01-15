using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using looply.Models;
using looply.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace looply.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var createdUser = await _userService.Register(user);
            if(createdUser == null) return BadRequest();
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login ([FromBody] User user)
        {
            var authenticatedUser = await _userService.Login(user.Email, user.Password);

            if(authenticatedUser != null)
            {
                return Ok(authenticatedUser);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUser (string id)
        {
            var deletedUser = await _userService.DeleteUser(id);

            if(deletedUser != null)
            {
                return Ok("Removed");
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("profile/{id}")]
        public async Task<IActionResult> GetUserById (string id)
        {
            var user = await _userService.GetUserById(id);

            if(user != null) return Ok(user);

            return NotFound();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update ([FromBody] User user)
        {
            var updatedUser = await _userService.UpdateUser(user);

            if(updatedUser  != null)
            {
                return Ok(updatedUser);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("follow")]
        public async Task<IActionResult> Follow([FromBody] Follower follow)
        {
            var result = await _userService.Follow(follow);

            if(result == -1) return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Route("unfollow")]
        public async Task<IActionResult> Unfollow([FromBody] Follower follow)
        {
            var result = await _userService.Unfollow(follow);

            if(result == -1) return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("followers/{id:guid}")]
        public async Task<IActionResult> Followers(Guid id)
        {
            var result = await _userService.Followers(id);

            if(result == null) return BadRequest();

            return Ok(result);
        }
        [HttpGet]
        [Route("following/{id:guid}")]
        public async Task<IActionResult> Following(Guid id)
        {
            var result = await _userService.Following(id);

            if(result == null) return BadRequest();

            return Ok(result);
        }
    }
}