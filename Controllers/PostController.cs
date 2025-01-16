using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using looply.DTO;
using looply.Models;
using looply.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace looply.Controllers
{
    [Route("api/v1/[controller]")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;

        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] Post post)
        {
            var createdPost = await _postService.Create(post);
            if(createdPost == null) return BadRequest();
            return Ok(createdPost);
        }

        [HttpDelete]
        [Route("delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedItem = await _postService.Delete(id);

            if(deletedItem == null) return BadRequest();

            return NoContent();
        }

        [HttpGet]
        [Route("myposts/{id:guid}")]
        public async Task<IActionResult> GetUsersPosts(Guid id)
        {
            var posts = await _postService.GetAllPostByUser(id);

            if(posts == null) return BadRequest("Not Found");

            return Ok(posts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPost(Guid id)
        {
            var post = await _postService.GetPostsById(id);

            if(post == null) return BadRequest("Not Found");

            return Ok(post);
        }

        [HttpPost]
        [Route("like")]
        public async Task<IActionResult> Like([FromBody] PostLikes liked_post)
        {
            var likedPost = await _postService.LikePost(liked_post);
            if(likedPost == null) return BadRequest();
            return Ok(likedPost);
        }

        [HttpPut]
        [Route("update/{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdatePostDTO post, Guid id)
        {
            var updatedPost = await _postService.Update(post, id);
            if(updatedPost == null) return BadRequest();
            return Ok(updatedPost);
        }


    }
}