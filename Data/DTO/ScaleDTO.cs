using System.Collections.Generic;
using escala_server.Data.Models;

namespace escala_server.Data.DTO
{
    public class ScaleDTO : Scale
    {
        public List<Song> Songs { get; set; }
        public List<MemberScaleDTO> Members { get; set; }
    }
}