using CountryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WeatherS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<worldCitiesUser> userManager,
        JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost]
        public void Login()
        {

        }
    }
}
