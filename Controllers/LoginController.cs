using System;
using System.Threading.Tasks;
using escala_server.Auxiliary.Security.Classes;
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
        public async Task<object> SignIn(User user)
        {
            try
            {
                return await _loginService.SignIn(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public DateTime SignIn()
        {
            try
            {
                return DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}