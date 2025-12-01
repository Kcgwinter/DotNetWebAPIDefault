using DotNetWebAPIDefault.DTOs.Account;
using DotNetWebAPIDefault.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPIDefault.Controllers
{
    public class AccountController(UserManager<AppUser> userManager) : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        [HttpPost("{register}")]
        public async Task<IActionResult> Register(DTOs.Account.RegisterDto model)
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

                if (roleResult.Succeeded) return Ok("User Created and added to role User");
            }
            return BadRequest("Error creating User");
        }
    }
}
