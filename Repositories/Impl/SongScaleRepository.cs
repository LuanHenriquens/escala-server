using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using escala_server.Data;
using escala_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace escala_server.Repositories.Impl
{
    public class SongScaleRepository : ISongScaleRepository
    {
        private readonly Context _context;
        public SongScaleRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<SongScale>> GetByScale(int scaleId)
        {
            return await _context.SongScale.Where(c => c.ScaleId == scaleId).ToListAsync();
        }
    }
}