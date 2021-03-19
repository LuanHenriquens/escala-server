
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using escala_server.Auxiliary;
using escala_server.Data.DTO;
using escala_server.Data.Models;
using escala_server.Middleware.Exceptions;
using escala_server.Repositories;
using escala_server.Auxiliary.Security;

namespace escala_server.Services.Impl
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly Validator _validator;
        private readonly IEncrypt _encrypt;
        public MemberService(IMemberRepository memberRepository,
            Validator validator,
            IEncrypt encrypt)
        {
            _memberRepository = memberRepository;
            _validator = validator;
            _encrypt = encrypt;
        }
        public async Task<MemberLoginDTO> Registration(MemberRegistrationDTO memberRegistration)
        {
            try
            {
                ValidatesRegistration(memberRegistration);
                
                Member member = new Member();
                member.Name = memberRegistration.Name;
                member.Email = memberRegistration.Email;
                member.SecretWord = _encrypt.EncryptPassword(memberRegistration.SecretWord);
                member.Active = true;

                member = await _memberRepository.Insert(member);

                MemberLoginDTO memberDTO = new MemberLoginDTO();
                memberDTO.Id = member.Id;
                memberDTO.Name = member.Name;
                memberDTO.Email = member.Email;
                memberDTO.Image = member.Image;
                memberDTO.Adm = member.Adm;

                return memberDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ValidatesRegistration(MemberRegistrationDTO member)
        {
            if(string.IsNullOrEmpty(member.Name))
                throw new ValidationException("Favor informar o nome.");
            if(string.IsNullOrEmpty(member.Email))
                throw new ValidationException("Favor informar o email.");
            if(!_validator.EmailValidator(member.Email))
                throw new ValidationException("Favor informar um email válido.");
            if(string.IsNullOrEmpty(member.SecretWord))
                throw new ValidationException("Favor informar a senha.");
            
            var min = member.SecretWord.Length - Regex.Replace(member.SecretWord, "[a-z]", "").Length;
            var mai = member.SecretWord.Length - Regex.Replace(member.SecretWord, "[A-Z]", "").Length;
            var numbers = member.SecretWord.Length - Regex.Replace(member.SecretWord, "[0-9]", "").Length;
            var symbols = member.SecretWord.Length - Regex.Replace(member.SecretWord, "[!@#$%&;*]", "").Length;

            if(member.SecretWord.Length < 8)
                throw new ValidationException("Senha precisa conter ao menos 8 caracteres.");
            if(min == 0)
                throw new ValidationException("Senha precisa conter ao menos 1 letra minúscula.");
            if(mai == 0)
                throw new ValidationException("Senha precisa conter ao menos 1 letra maiúscula.");
            if(numbers == 0)
                throw new ValidationException("Senha precisa conter ao menos 1 número.");
            if(symbols == 0)
                throw new ValidationException("Senha precisa conter ao menos 1 caracter especial.");
        }
    }
}