using System.Collections.Generic;
using System.Threading.Tasks;
using escala_server.Data.DTO;
using escala_server.Data.Models;

namespace escala_server.Repositories
{
    public interface ISongRepository
    {
        Task<List<HomeSongsDTO>> GetByScaleForHome(long scaleId);
        Task<List<Song>> GetByScale(long scaleId);
    }
}