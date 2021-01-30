using System;
using System.Threading.Tasks;
using escala_server.Data;
using escala_server.Models;

namespace escala_server.Repositories.Impl
{
    public class MemberRepository : IMemberRepository
    {
        private readonly Context _context;
        public MemberRepository(Context context)
        {
            _context = context;
        }
        public async Task<Member> Insert(Member member)
        {
            try
            {
                await _context.Member.AddAsync(member);
                await _context.SaveChangesAsync();

                return member;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir o membro.");
            }
        }
    }
}