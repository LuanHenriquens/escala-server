using System;
using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class Song
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Singer { get; set; }
        public string Link { get; set; }
        public string Solo { get; set; }
        public string Tone { get; set; }
        public int? Difficulty { get; set; }
        public DateTime? LastTime { get; set; }
        public Boolean Active { get; set; }
    }
}
