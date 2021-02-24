using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using escala_server.Auxiliary;
using escala_server.Data.DTO;
using escala_server.Repositories;

namespace escala_server.Services.Impl
{
    public class LoginService : ILoginService
    {
        private readonly Security _security;
        private readonly IMemberRepository _memberRepository;
        public LoginService(Security security, IMemberRepository memberRepository)
        {
            _security = security;
            _memberRepository = memberRepository;
        }
        public async Task<object> SignIn(LoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.UserEmail))
                throw new ValidationException("Informe o email de usuario");
            if (string.IsNullOrEmpty(loginDTO.PassWord))
                throw new ValidationException("Informe a senha");

            loginDTO.PassWord = _security.EncryptPassword(loginDTO.PassWord);
            var user = await _memberRepository.ValidateLogin(loginDTO);

            if (user == null)
                throw new UnauthorizedAccessException("Usuario ou senha inválidos");
            else return new
            {
                Name = user.Name,
                Image = user.Image,
                Adm = user.Adm
            };
        }
    }
}