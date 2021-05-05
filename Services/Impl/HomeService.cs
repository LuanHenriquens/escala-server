using System.Collections.Generic;
using System.Threading.Tasks;
using escala_server.Data.DTO;
using escala_server.Repositories;

namespace escala_server.Services.Impl
{
    public class HomeService : IHomeService
    {
        private readonly IScaleRepository _scaleRepository;
        private readonly ISongRepository _songRepository;
        public HomeService(IScaleRepository scaleRepository,
            ISongRepository songRepository)
        {
            _scaleRepository = scaleRepository;
            _songRepository = songRepository;
        }

        public async Task<HomePageDTO> GenerateHomePage(string name)
        {
            var scales = await _scaleRepository.GetByDate();
            var homeScales = new List<HomeScalesDTO>();

            scales.ForEach(async c => 
                homeScales.Add(new HomeScalesDTO()
                {
                    Id = c.Id,
                    Date = c.Day,
                    Songs = await _songRepository.GetByScaleForHome(c.Id)
                }));

            return new HomePageDTO()
            {
                Name = name,
                HomeScalesDTO = homeScales
            };
        }
    }
}