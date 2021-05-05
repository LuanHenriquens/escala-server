using System.Collections.Generic;
using System.Threading.Tasks;
using escala_server.Data.Models;

namespace escala_server.Repositories
{
    public interface ISongScaleRepository
    {
        Task<List<SongScale>> GetByScale(int scaleId);
    }
}