using System;
using System.Threading.Tasks;
using escala_server.Auxiliary;
using escala_server.Data;
using escala_server.Data.DTO;
using escala_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace escala_server.Repositories.Impl
{
    public class MemberRepository : IMemberRepository
    {
        private readonly Context _context;
        private readonly Security _security;
        public MemberRepository(Context context,Security security)
        {
            _context = context;
            _security = security;
        }
        public async Task<Member> Insert(Member member)
        {
            try
            {
                await _context.Member.AddAsync(member);
                await _context.SaveChangesAsync();

                return member;
            }
            catch
            {
                throw new Exception("Não foi possível inserir o membro.");
            }
        }
        public async Task<Member> ValidateLogin(LoginDTO loginDTO)
        {
            try
            {
                var member = await _context.Member.FirstOrDefaultAsync(c => c.Email == loginDTO.UserEmail &&
                                                                c.SecretWord == loginDTO.PassWord &&
                                                                c.Active);
                await _context.SaveChangesAsync();

                return member;
            }
            catch
            {
                throw new Exception("Não foi possível inserir o membro.");
            }
        }
    }
}