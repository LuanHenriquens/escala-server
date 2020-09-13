using System;
using System.ComponentModel.DataAnnotations;

namespace escala_server.Data.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Singer { get; set; }

        public string Link { get; set; }

        public string Solo { get; set; }

        public string Tone { get; set; }

        public int? Difficulty { get; set; }

        public DateTime? LastTime { get; set; }

        public bool Active { get; set; }
    }
}
