using ECommerce.Basket.LoginServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public BasketController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = User.Claims;
            return Ok("kullanıcı geldi");
        }

    }
}
