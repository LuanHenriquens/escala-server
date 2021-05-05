using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using escala_server.Data;
using escala_server.Data.DTO;
using escala_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace escala_server.Repositories.Impl
{
    public class ScaleRepository : IScaleRepository
    {
        private readonly Context _context;
        public ScaleRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<Scale>> GetByDate()
        {
            return await _context.Scale.Where(c => c.Day >= DateTime.Now).Take(5).ToListAsync();
        }

        public async Task<Scale> GetById(long id)
        {
            return await _context.Scale.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Scale>> GetAllForHistory()
        {
            return await _context.Scale.Where(c => c.Active == true).ToListAsync();
        }
    }
}