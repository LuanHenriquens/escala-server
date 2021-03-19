using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using escala_server.Auxiliary.Security.Classes;
using escala_server.Repositories;
using System.IdentityModel.Tokens.Jwt;
using escala_server.Data.Models;
using Microsoft.IdentityModel.Tokens;

namespace escala_server.Auxiliary.Security.Impl
{
    public class AccessManager : IAccessManager
    {
        private readonly IEncrypt _encrypt;
        private readonly IMemberRepository _memberRepository;
        private readonly TokenConfigurations _tokenConfig;
        private readonly SigningConfigurations _signingConfig;
        public AccessManager(IEncrypt encrypt, IMemberRepository memberRepository,
                            TokenConfigurations tokenConfig,SigningConfigurations signingConfig)
        {
            _encrypt = encrypt;
            _memberRepository = memberRepository;
            _tokenConfig = tokenConfig;
            _signingConfig = signingConfig;
        }
        public async Task<Member> ValidateCredentials(User user)
        {
            if (string.IsNullOrEmpty(user.UserEmail))
                throw new ValidationException("Informe o email de usuario."); // TODO: Alterar para o Midleware exception
            if (string.IsNullOrEmpty(user.PassWord))
                throw new ValidationException("Informe a senha."); // TODO: Alterar para o Midleware exception

            user.PassWord = _encrypt.EncryptPassword(user.PassWord);
            var member = await _memberRepository.ValidateLogin(user);

            if (member == null)
                throw new ValidationException("Usuario ou senha inválidos.");
            
            return member;
        }

        public Token GenerateToken(Member member)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(member.Email, "Login"),
                new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim("member_id", member.Id.ToString()),
                    new Claim("member_name", member.Name.ToString())
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenConfig.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = _signingConfig.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new Token()
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "OK"
            };
        }
    }
}