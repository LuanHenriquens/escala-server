using System.Threading.Tasks;
using escala_server.Data.DTO;

namespace escala_server.Services
{
    public interface ILoginService
    {
         Task<object> SignIn(LoginDTO loginDTO);
    }
}