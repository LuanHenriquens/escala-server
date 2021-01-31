using System.Threading.Tasks;
using escala_server.Data.DTOs;
using escala_server.Data.Models;
using escala_server.Repositories.Impl;

namespace escala_server.Services.Impl
{
    public class MemberService : IMemberService
    {
        private readonly MemberRepository _memberRepository;
        public MemberService(MemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<MemberLoginDTO> Registration(MemberRegistrationDTO memberRegistration)
        {
            //TODO: validar name
            //TODO: validar email
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

            return member;
        }
    }
}