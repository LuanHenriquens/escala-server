using System.Threading.Tasks;
using escala_server.Auxiliary.Security.Classes;
using escala_server.Data.Models;

namespace escala_server.Repositories
{
    public interface IMemberRepository
    {   
        Task<Member> Insert(Member member);
        Task<Member> ValidateLogin(User user);
    }
}