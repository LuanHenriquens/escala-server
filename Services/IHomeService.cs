using System.Threading.Tasks;
using escala_server.Data.DTO;

namespace escala_server.Services
{
    public interface IHomeService
    {
        Task<HomePageDTO> GenerateHomePage(string name);
    }
}