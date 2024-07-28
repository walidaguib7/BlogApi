using BlogApi.Dtos.Followers;
using BlogApi.Helpers;
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
        [Route("followers/{userId}")]
        
        public async Task<IActionResult> GetFollowers([FromRoute] string userId , [FromQuery] UsersQuery query)
        {
            var followers = await _followRepo.GetFollowers(userId , query);
            var followersDto = followers.Select(f => f.ToFollowerDto());
            return Ok(followersDto);
        }

        [HttpGet]
        [Route("followings/{MyUser}")]
        
        public async Task<IActionResult> GetFollowings([FromRoute] string MyUser , [FromQuery] UsersQuery query)
        {
            var followings = await _followRepo.GetFollowings(MyUser , query);
            var followingsDto = followings.Select(f => f.ToFollowingDto());
            return Ok(followingsDto);
        }


        [HttpGet]
        [Route("{user}/{followId}")]
        
        public async Task<IActionResult> GetFollow(string user , string followId)
        {
            var MyUser = await _followRepo.GetFollow(user, followId);
            if (MyUser == null) return NotFound();
            return StatusCode(201,"there is follow relation between user and follower user");
        }



        [HttpPost]
        
        public async Task<IActionResult> FollowUser([FromBody] CreateFollowDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var followModel = dto.ToUserFollower();
            await _followRepo.Follow(followModel);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{MyUserId}/{targetId}")]
        
        public async Task<IActionResult> UnFollow(string MyUserId , string targetId)
        {
            var model = await _followRepo.UnFollow(MyUserId, targetId);
            if (model == null) return NotFound();
            return Ok($"Unfollow successfully");
        }



  
    }
}
