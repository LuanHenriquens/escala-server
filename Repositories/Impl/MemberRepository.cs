using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using escala_server.Auxiliary.Security.Classes;
using escala_server.Data;
using escala_server.Data.DTO;
using escala_server.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            catch
            {
                throw new Exception("Não foi possível inserir o membro.");
            }
        }
        public async Task<Member> ValidateLogin(User loginDTO)
        {
            try
            {
                var member = await _context.Member.FirstOrDefaultAsync(c => c.UserName == loginDTO.UserName &&
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
        public async Task<List<MemberScaleDTO>> GetByScaleForScale(long scaleId)
        {
            return await (from m in _context.Member
                join ms in _context.MemberScale on m.Id equals ms.MemberId
                where ms.ScaleId == scaleId
                select new MemberScaleDTO()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Image = m.Image
                }).ToListAsync();
        }
    }
}