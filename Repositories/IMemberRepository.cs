using System.Threading.Tasks;
using escala_server.Data.DTOs;
using escala_server.Data.Models;

namespace escala_server.Repositories
{
    public interface IMemberRepository
    {   
        Task<Member> Insert(Member member);
    }
}