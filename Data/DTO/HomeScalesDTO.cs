using System;
using System.Collections.Generic;

namespace escala_server.Data.DTO
{
    public class HomeScalesDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public List<HomeSongsDTO> Songs { get; set; }
    }
}