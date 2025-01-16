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
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;

        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] Comment comment)
        {
            var createdComment = await _commentService.Create(comment);
            if(createdComment == null) return BadRequest();
            return Ok(createdComment);
        }
        [HttpDelete]
        [Route("delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedComment = await _commentService.Delete(id);
            if(deletedComment == null) return BadRequest();
            return Ok(deletedComment);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAllByPostID(Guid id)
        {
            var comments = await _commentService.GetCommentsByPostId(id);
            if(comments  == null) return BadRequest();
            return Ok(comments);
        }

        [HttpPost]
        [Route("like")]
        public async Task<IActionResult> Like([FromBody] CommentLikes liked_comment)
        {
            var result = await _commentService.Like(liked_comment);
            if(result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("unlike")]
        public async Task<IActionResult> Unlie([FromBody] CommentLikes liked_comment)
        {
            var result = await _commentService.Unlike(liked_comment);
            if(result == null) return BadRequest();
            return Ok(result);
        }
    }
}