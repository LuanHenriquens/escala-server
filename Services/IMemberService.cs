using System.Threading.Tasks;
using escala_server.Data.DTO;

namespace escala_server.Services
{
    public interface IMemberService
    {
        Task<LoginReturnDTO> Registration(MemberRegistrationDTO memberRegistration);
    }
}