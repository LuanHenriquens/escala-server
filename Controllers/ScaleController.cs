using System.Collections.Generic;
using System.Threading.Tasks;
using escala_server.Data.DTO;
using escala_server.Data.Models;
using escala_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace escala_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaleController : Controller
    {
        private readonly IScaleService _scaleService;
        public ScaleController(IScaleService scaleService)
        {
            _scaleService = scaleService;
        }

        [HttpGet]
        public async Task<Scale> GetById(long id)
        {
            return await _scaleService.GetById(id);
        }
        [HttpGet("history")]
        public async Task<List<HistoryDTO>> GetAllForHistory()
        {
            return await _scaleService.GetAllForHistory();
        }
    }
}