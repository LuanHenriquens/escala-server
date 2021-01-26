using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class Function
    {
        [Key]
        public long Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}