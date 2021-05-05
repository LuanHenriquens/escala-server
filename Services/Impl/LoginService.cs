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
        public LoginService(IAccessManager accessManager)
        {
            _accessManager = accessManager;
        }
        public async Task<LoginReturnDTO> SignIn(User user)
        {
            try
            {
                var member = await _accessManager.ValidateCredentials(user);
                var token = _accessManager.GenerateToken(member);

                return new LoginReturnDTO()
                {
                    Name = member.Name,
                    Email = member.Email,
                    Image = member.Image,
                    Adm = member.Adm,
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