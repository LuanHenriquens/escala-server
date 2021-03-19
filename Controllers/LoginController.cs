using System;
using System.Threading.Tasks;
using escala_server.Auxiliary.Security;
using escala_server.Auxiliary.Security.Classes;
using Microsoft.AspNetCore.Mvc;

namespace escala_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IAccessManager _accessManager;
        public LoginController(IAccessManager accessManager)
        {
            _accessManager = accessManager;
        }
        
        [HttpPost]
        public async Task<Token> SignIn(User user)
        {
            try
            {
                var member = await _accessManager.ValidateCredentials(user);
                
                return _accessManager.GenerateToken(member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}