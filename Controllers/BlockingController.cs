using BlogApi.Dtos.Blocking;
using BlogApi.Helpers;
using BlogApi.Interfaces;
using BlogApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/blocking")]
    [ApiController]
    public class BlockingController(IBlockedUser _blockedUserRepo) : ControllerBase
    {
        private readonly IBlockedUser blockedUserRepo = _blockedUserRepo;

        [HttpGet]
        [Route("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetBlockedUsers([FromRoute] string userId, [FromQuery] UsersQuery query)
        {
            var users = await blockedUserRepo.GetBlockedUsers(userId , query);
            var usersDto = users.Select(u => u.ToBlockedUserDto());
            return Ok(usersDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BlockUser([FromBody] CreateBlockedUser blockedUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = blockedUser.ToBlockedUser();
            await blockedUserRepo.BlockUser(user);
            return Ok("User Blocked!");
        }

        [HttpDelete]
        [Authorize]
        [Route("{userId}/{blockedId}")]
        public async Task<IActionResult> UnBlock( string userId , string blockedId)
        {
            var user = await blockedUserRepo.UnBlockUser(userId , blockedId);
            if (user == null) return NotFound();
            return Ok("User unblocked!");
        }
    }
}
