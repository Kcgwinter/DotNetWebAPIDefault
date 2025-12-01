using DotNetWebAPIDefault.DTOs.Account;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPIDefault.Controllers
{
    public class AccountController(UserManager<AppUser> userManager, ITokenService tokenService) : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost("{register}")]
        public async Task<IActionResult> Register(DTOs.Account.RegisterDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,

                };
                var createUser = await _userManager.CreateAsync(appUser, model.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if (roleResult.Succeeded)
                    {
                        new CreateUserDto
                        {
                            Username  = appUser.UserName,
                            Email  =  appUser.Email,
                            Token  = _tokenService.CreateToken(appUser)
                        };
                    }
                }
                return BadRequest("Error creating User");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
