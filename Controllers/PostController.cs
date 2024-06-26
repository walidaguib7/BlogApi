using BlogApi.Dtos.Posts;
using BlogApi.Helpers;
using BlogApi.Interfaces;
using BlogApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController(IPost postRepo) : ControllerBase
    {
        private readonly IPost _postRepo = postRepo;

        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] PostQuery query)
        {
            var posts = await _postRepo.GetPosts(query);
            var post = posts.Select(p => p.ToPostDto());
            return Ok(post);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
        {
            var post = await _postRepo.GetPost(id);
            if (post == null) return NotFound();
            return Ok(post.ToPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var post = postDto.ToPostModel();
             await _postRepo.CreatePost(post);
            return StatusCode(200, "Post created successfully!");
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDto postDto , [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var post = await _postRepo.UpdatePost(id, postDto);
            if (post == null) return NotFound();
            return StatusCode(200, "Post Updated successfully!");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            await _postRepo.DeletePost(id);
            return Ok("Post deleted successfully!");
        }
    }
}
