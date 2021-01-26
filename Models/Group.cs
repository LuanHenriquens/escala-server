using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class Group
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
