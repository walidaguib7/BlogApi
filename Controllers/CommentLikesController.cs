using BlogApi.Dtos.Likes;
using BlogApi.Interfaces;
using BlogApi.Mappers;
using BlogApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/CommentLikes")]
    [ApiController]
    public class CommentLikesController(UserManager<User> manager , ICommentLikes commentLikesRepo , IComment commentRepo) : ControllerBase
    {
        private readonly UserManager<User> _manager = manager;
        private readonly ICommentLikes _commentLikesRepo = commentLikesRepo;
        private readonly IComment _commentRepo = commentRepo;

        [HttpPost]
        public async Task<IActionResult> LikeComment([FromBody] LikeCommentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var user = await _manager.FindByIdAsync(dto.UserId);
                if (user == null) return NotFound();
                var comment = await _commentRepo.GetComment(dto.CommentId);
                if (comment == null) return NotFound();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            var like = dto.ToCommentLikes();
            await _commentLikesRepo.LikeComment(like);

            return Ok($"Comment {like.CommentId} like by user n {like.UserId}");
        }

        [HttpDelete]
        [Route("{id:int}/{userId}")]
        public async Task<IActionResult> UnlikeComment([FromRoute] int id , string userId)
        {
            await _commentLikesRepo.UnlikeComment(userId, id);
            return Ok("unliked");
        }

    }
}
