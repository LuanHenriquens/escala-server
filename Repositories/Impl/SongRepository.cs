using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using escala_server.Data;
using escala_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace escala_server.Repositories.Impl
{
    public class SongRepository
    {
        private readonly Context _context;
        public SongRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<Song>> GetAll() =>
            await _context.Song.ToListAsync();
        
        public async Task<Song> GetById(long id) =>
            await _context.Song.FirstOrDefaultAsync(c => c.Id == id);
        
        public async Task Insert(Song song)
        {
            await _context.AddAsync(song);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Song song)
        {
            _context.Update(song);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Song song)
        {
            _context.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
}