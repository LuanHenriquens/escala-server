using System;
using System.Threading.Tasks;
using escala_server.Auxiliary.Security;
using escala_server.Auxiliary.Security.Classes;
using escala_server.Data.DTO;

namespace escala_server.Services.Impl
{
    public class LoginService : ILoginService
    {
        private readonly IAccessManager _accessManager;
        private readonly IHomeService _homeService;
        public LoginService(IAccessManager accessManager,
            IHomeService homeService)
        {
            _accessManager = accessManager;
            _homeService = homeService;
        }
        public async Task<LoginReturnDTO> SignIn(User user)
        {
            try
            {
                var member = await _accessManager.ValidateCredentials(user);
                var token = _accessManager.GenerateToken(member);
                var home = await _homeService.GenerateHomePage(member.Name);

                return new LoginReturnDTO()
                {
                    Image = member.Image,
                    Adm = member.Adm,
                    Home = home,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}