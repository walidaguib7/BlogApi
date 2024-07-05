﻿using BlogApi.Dtos.User;
using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> manager) : ControllerBase
    {
        private readonly UserManager<User> userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly SignInManager<User> _manager = manager;


        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto , [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid");
                }
                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    filesId = id,
                    first_name = registerDto.first_name,
                    last_name = registerDto.last_name,
                    bio = registerDto.bio ,
                    
                    

                };
                var createdUser = await userManager.CreateAsync(user, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    return Ok(
                             new NewUser
                             {
                                 Email = user.Email,
                                 Username = user.UserName,
                                 Token = _tokenService.CreateToken(user),
                             }
                             );
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await userManager.Users.Include(u => u.files).FirstOrDefaultAsync(u => u.UserName == loginDto.Username);
            if (user == null) return Unauthorized("Invalid username");
            var result = await _manager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Username / Password wrong , re-try!");

            return Ok(
                new NewUser
                {
                    UserId = user.Id,
                    Username = loginDto.Username,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                    first_name = user.first_name,
                    last_name = user.last_name,
                    bio = user.bio,
                    Picture = user.files.Image,
                    PictureId = user.filesId,
                    friends = user.friends.ToList() 
                });
        }
    }
}
