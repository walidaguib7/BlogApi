using BlogApi.Data;
using BlogApi.Dtos.Likes;
using BlogApi.Extensions;
using BlogApi.Interfaces;
using BlogApi.Mappers;
using BlogApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/likes")]
    [ApiController]
    public class LikesController(ILike likeRepo , UserManager<User> _manager , IPost _postRepo ) : ControllerBase
    {
        private readonly ILike _likeRepo = likeRepo;
        private readonly UserManager<User> manager  = _manager;
        private readonly IPost postRepo = _postRepo;

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LikePost([FromBody] LikePostDto postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            
            var user = await manager.FindByIdAsync(postDto.UserId);
            if (user == null) return BadRequest("user not found!");

            var post = await postRepo.GetPost(postDto.PostId);
            if (post == null) return BadRequest("post not found!");

            var like = postDto.ToLikesModel();
            var myLike = await _likeRepo.LikePost(like);
            return StatusCode(201,$"Post number {myLike.PostId} is liked by User {myLike.UserId}");
        }

        [HttpDelete]
        [Route("{id:int}/{userId}")]
        [Authorize]
        public async Task<IActionResult> UnLike([FromRoute] int id , string userId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _likeRepo.Unlike(id, userId);

            return Ok("Unliked!");
        }
    }
}
