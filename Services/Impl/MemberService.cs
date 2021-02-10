
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using escala_server.Auxiliary;
using escala_server.Data.DTOs;
using escala_server.Data.Models;
using escala_server.Middleware.Exceptions;
using escala_server.Repositories;

namespace escala_server.Services.Impl
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly Validator _validator;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<MemberLoginDTO> Registration(MemberRegistrationDTO memberRegistration)
        {
            if(string.IsNullOrEmpty(memberRegistration.Name))
                throw new ValidationException("Favor informar o nome.");
            if(string.IsNullOrEmpty(memberRegistration.Email))
                throw new ValidationException("Favor informar o email.");
            if(_validator.EmailValidator(memberRegistration.Email))
                throw new ValidationException("Favor informar um email válido.");
            if(string.IsNullOrEmpty(memberRegistration.SecretWord))
                throw new ValidationException("Favor informar a senha.");
            
            //TODO: validar senha

            //TODO: encriptar senha

            Member member = new Member();
            member.Name = memberRegistration.Name;
            member.Email = memberRegistration.Email;
            member.SecretWord = memberRegistration.SecretWord;

            member = await _memberRepository.Insert(member);

            MemberLoginDTO memberDTO = new MemberLoginDTO();
            memberDTO.Id = member.Id;
            memberDTO.Name = member.Name;
            memberDTO.Email = member.Email;
            memberDTO.Image = member.Image;
            memberDTO.Adm = member.Adm;

            return memberDTO;
        }
    }
}