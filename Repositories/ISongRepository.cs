using System.Threading.Tasks;
using escala_server.Data.Models;

namespace escala_server.Repositories
{
    public interface ISongRepository
    {
        Task<Song> GetAll();
        Task<Song> GetById(long id);
        Task Insert(Song song);
        Task Update(Song song);
        Task Delete(long id);
    }
}