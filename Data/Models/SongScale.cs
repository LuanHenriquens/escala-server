using System.ComponentModel.DataAnnotations;

namespace escala_server.Data.Models
{
    public class SongScale
    {
        [Key]
        public int Id { get; set; }

        public int ScaleId { get; set; }

        public int SongId { get; set; }
    }
}
