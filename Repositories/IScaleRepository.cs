using System.Collections.Generic;
using System.Threading.Tasks;
using escala_server.Data.DTO;
using escala_server.Data.Models;

namespace escala_server.Repositories
{
    public interface IScaleRepository
    {
        Task<List<Scale>> GetByDate();
        Task<Scale> GetById(long id);
        Task<List<Scale>> GetAllForHistory();
    }
}