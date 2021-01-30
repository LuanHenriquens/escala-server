using System.Threading.Tasks;
using escala_server.Models;

namespace escala_server.Repositories
{
    public interface IMemberRepository
    {   
        Task<Member> Insert(Member member);
    }
}