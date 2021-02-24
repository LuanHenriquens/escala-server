using System.Threading.Tasks;
using escala_server.Data.DTO;
using escala_server.Data.Models;

namespace escala_server.Services
{
    public interface IMemberService
    {
        Task<MemberLoginDTO> Registration(MemberRegistrationDTO memberRegistration);
    }
}