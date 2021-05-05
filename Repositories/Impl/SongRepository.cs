using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using escala_server.Data;
using escala_server.Data.DTO;
using escala_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace escala_server.Repositories.Impl
{
    public class SongRepository : ISongRepository
    {
        private readonly Context _context;
        public SongRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<HomeSongsDTO>> GetByScaleForHome(long scaleId)
        {
            return await (from s in _context.Song
                join ss in _context.SongScale on s.Id equals ss.SongId
                where ss.ScaleId == scaleId
                select new HomeSongsDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Singer = s.Singer
                }).ToListAsync();
        }
        public async Task<List<string>> GetByScaleForHistory(long scaleId)
        {
            return await (from s in _context.Song
                join ss in _context.SongScale on s.Id equals ss.SongId
                where ss.ScaleId == scaleId
                select s.Name).ToListAsync();
        }

        public async Task<List<Song>> GetByScale(long scaleId)
        {
            return await (from s in _context.Song
                join ss in _context.SongScale on s.Id equals ss.SongId
                where ss.ScaleId == scaleId
                select s).ToListAsync();
        }
    }
}