using BlogApi.Dtos.Comments;
using BlogApi.Helpers;
using BlogApi.Interfaces;
using BlogApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController(IComment commentRepo) : ControllerBase
    {
        private readonly IComment _commentRepo = commentRepo;

        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetComments();
            var comment = comments.Select(c => c.ToCommentDto());
            return Ok(comment);
        }

        [HttpGet]
        [Route("{id:int}")]
        
        public async Task<IActionResult> FindComment([FromRoute] int id)
        {
            var comment = await _commentRepo.GetComment(id);
            if (comment == null) return NotFound();
            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var comment = commentDto.ToCommentModel();
            await _commentRepo.CreateComment(comment);
            return StatusCode(200 , "Comment created successfully");
        }

        [HttpPut]
        [Route("{id:int}")]
        
        public async Task<IActionResult> UpdateComment([FromRoute] int id , [FromBody] UpdateCommentDto commentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var comment = await _commentRepo.UpdateComment(id, commentDto);
            if (comment == null) return NotFound();
            return StatusCode(200,"Comment Updated Successfully");
        }

        [HttpDelete]
        [Route("{id:int}")]
        
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _commentRepo.DeleteComment(id);
            return Ok("Comment deleted successfully!");
        }

    }
}
