using System;
using System.Threading.Tasks;
using escala_server.Data.DTO;
using escala_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace escala_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        
        [HttpPost]
        public async Task<ActionResult<object>> SignIn(LoginDTO loginDTO)
        {
            try
            {
                return await _loginService.SignIn(loginDTO);
            }
            catch (Exception ex)
            {
                return new Exception(ex.Message);
            }
        }
    }
}