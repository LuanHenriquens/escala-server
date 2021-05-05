using System.Collections.Generic;

namespace escala_server.Data.DTO
{
    public class HomePageDTO
    {
        public string Name { get; set; }
        public List<HomeScalesDTO> HomeScalesDTO { get; set; }
        
    }
}