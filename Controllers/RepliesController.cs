using BlogApi.Dtos.Replies;
using BlogApi.Interfaces;
using BlogApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/replies")]
    [ApiController]
    public class RepliesController(IReply replyRepo) : ControllerBase
    {
        private readonly IReply _replyRepo = replyRepo;

        [HttpGet]
        
        public async Task<IActionResult> GetReplies()
        {
            var replies = await _replyRepo.GetReplies();
            var repliesDto = replies.Select(r => r.ToReplyDto());
            return Ok(repliesDto);
        }

        [HttpPost]
        
        public async Task<IActionResult> PostReply([FromBody] CreateReplyDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var reply = dto.ToReplyModel();
            await _replyRepo.CreateReply(reply);
            return Ok("Reply published!");
        }

        [HttpPut]
        [Route("{id:int}")]
        
        public async Task<IActionResult> UpdateReply([FromRoute] int id , [FromBody] UpdateReplyDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var reply = await _replyRepo.UpdateReply(id, dto);
            if (reply == null) return NotFound();
            return Ok("Reply updated!");
        }

        [HttpDelete]
        [Route("{id:int}")]
        
        public async Task<IActionResult> DeleteReply([FromRoute] int id)
        {
            await _replyRepo.DeleteReply(id);
            return Ok("Deleted!");
        }
    }
}
