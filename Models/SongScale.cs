using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class SongScale
    {
        [Key]
        public long Id { get; set; }
        public long ScaleId { get; set; }
        public long SongId { get; set; }
        public bool Active { get; set; }
    }
}
