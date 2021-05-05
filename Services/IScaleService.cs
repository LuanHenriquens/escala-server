using System.Collections.Generic;
using System.Threading.Tasks;
using escala_server.Data.DTO;

namespace escala_server.Services
{
    public interface IScaleService
    {
        Task<ScaleDTO> GetById(long id);
        Task<List<HistoryDTO>> GetAllForHistory();
    }
}