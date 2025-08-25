using api.Dtos.Comments;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController(ICommentService commentService) : ControllerBase
    {
        private readonly ICommentService _commentService = commentService;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CommentQueryObject query)
        {
            var comments = await _commentService.ListAllCommentsAsync(query);
            return Ok(comments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            var comment = await _commentService.DetailCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentDto commentDto)
        {
            var comment = await _commentService.AddCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetId), new { id = comment.Id }, comment);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] CommentDto commentDto)
        {
            var comment = await _commentService.EditCommentAsync(id, commentDto);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var comment = await _commentService.RemoveCommentAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}