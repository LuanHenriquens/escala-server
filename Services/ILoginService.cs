using System.Threading.Tasks;
using escala_server.Auxiliary.Security.Classes;
using escala_server.Data.DTO;

namespace escala_server.Services
{
    public interface ILoginService
    {
        Task<LoginReturnDTO> SignIn(User user);
    }
}