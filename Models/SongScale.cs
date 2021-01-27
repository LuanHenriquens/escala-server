namespace escala_server.Models
{
    public class SongScale
    {
        public long ScaleId { get; set; }
        public long SongId { get; set; }
        public bool Active { get; set; }

        public Song Song { get; set; }
        public Scale Scale { get; set; }
    }
}
