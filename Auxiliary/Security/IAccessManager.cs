using System.Threading.Tasks;
using escala_server.Auxiliary.Security.Classes;
using escala_server.Data.Models;

namespace escala_server.Auxiliary.Security
{
    public interface IAccessManager
    {
        Task<Member> ValidateCredentials(User user);
        Token GenerateToken(Member member);
    }
}