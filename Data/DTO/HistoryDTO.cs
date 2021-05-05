using System.Collections.Generic;
using escala_server.Data.Models;

namespace escala_server.Data.DTO
{
    public class HistoryDTO : Scale
    {
        public List<string> Songs { get; set; }
    }
}