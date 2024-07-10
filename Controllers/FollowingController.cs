using BlogApi.Dtos.Followers;
using BlogApi.Interfaces;
using BlogApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/following")]
    [ApiController]
    public class FollowingController(IFollow followRepo) : ControllerBase
    {
        private readonly IFollow _followRepo = followRepo;


        [HttpGet]
        [Route("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetFollowers([FromRoute] string userId)
        {
            var followers = await _followRepo.GetFollowers(userId);
            var followersDto = followers.Select(f => f.ToFollowerDto());
            return Ok(followersDto);
        }

        [HttpGet]
        [Route("following/{MyUser}")]
        [Authorize]
        public async Task<IActionResult> GetFollowings([FromRoute] string MyUser)
        {
            var followings = await _followRepo.GetFollowings(MyUser);
            var followingsDto = followings.Select(f => f.ToFollowingDto());
            return Ok(followingsDto);
        }


        [HttpGet]
        [Route("{user}/{followId}")]
        [Authorize]
        public async Task<IActionResult> GetFollow(string user , string followId)
        {
            var MyUser = await _followRepo.GetFollow(user, followId);
            if (MyUser == null) return NotFound();
            return StatusCode(201,"there is follow relation between user and follower user");
        }



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> FollowUser([FromBody] CreateFollowDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var followModel = dto.ToUserFollower();
            await _followRepo.Follow(followModel);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{MyUserId}/{targetId}")]
        [Authorize]
        public async Task<IActionResult> UnFollow(string MyUserId , string targetId)
        {
            var model = await _followRepo.UnFollow(MyUserId, targetId);
            if (model == null) return NotFound();
            return Ok($"Unfollow successfully");
        }



  
    }
}
