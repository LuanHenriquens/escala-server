using System.Collections.Generic;
using System.Threading.Tasks;
using escala_server.Data.DTO;
using escala_server.Data.Models;
using escala_server.Repositories;

namespace escala_server.Services.Impl
{
    public class ScaleService : IScaleService
    {
        private readonly IScaleRepository _scaleRepository;
        private readonly ISongRepository _songRepository;
        private readonly IMemberRepository _memberRepository;
        public ScaleService(IScaleRepository scaleRepository,
            ISongRepository songRepository,
            IMemberRepository memberRepository)
        {
            _scaleRepository = scaleRepository;
            _songRepository = songRepository;
            _memberRepository = memberRepository;
        }
        public async Task<ScaleDTO> GetById(long id)
        {
            var scale = await _scaleRepository.GetById(id);
            var songs = await _songRepository.GetByScale(id);
            var members = await _memberRepository.GetByScaleForScale(id);

            return new ScaleDTO()
            {
                Id = scale.Id,
                Day = scale.Day,
                Songs = songs,
                Members = members
            };
        }
        public async Task<List<HistoryDTO>> GetAllForHistory()
        {
            var scales = await _scaleRepository.GetAllForHistory();
            var history = new List<HistoryDTO>();
            
            scales.ForEach(async c =>
                history.Add(new HistoryDTO()
                {
                    Id = c.Id,
                    Day = c.Day,
                    Songs = await _songRepository.GetByScaleForHistory(c.Id)
                }));

            return history;
        }
    }
}