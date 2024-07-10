using BlogApi.Dtos.Category;
using BlogApi.Interfaces;
using BlogApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BlogApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController(ICategory categoryRepo) : ControllerBase
    {
        private readonly ICategory _categoryRepo = categoryRepo;


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCategories()
        {
           
            var categories = await _categoryRepo.GetCategories();
            var category = categories.Select(c => c.ToCategoryDto());
            return Ok(category);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = await _categoryRepo.GetCategory(id);
            if (category == null) return NotFound();
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = categoryDto.ToCategoryModel();
            if (category == null) return NotFound();
             await _categoryRepo.CreateCategory(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id },category.ToCategoryDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto categoryDto , [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = await _categoryRepo.UpdateCategory(id , categoryDto);
            if (category == null) return NotFound();
            return Ok(category.ToCategoryDto());
        }


        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _categoryRepo.DeleteCategory(id);
            return Ok("Category deleted!");
        }
    }
}

