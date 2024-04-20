using CountryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WeatherS.DTO;

namespace WeatherS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<worldCitiesUser> userManager,
        JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            worldCitiesUser? user = await userManager.FindByNameAsync(loginRequest.Username);
            if (user == null)
            {
                return Unauthorized("Wrong username");
            }
            bool success = await userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!success)
            {
                return Unauthorized("Wrong password");
            }
            JwtSecurityToken token = await jwtHandler.GetTokenAsync(user);
            string jwtString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new LoginResult
            {
                Success = true,
                Message = "momlovesus",
                Token = jwtString
            });
        }
    }
}
