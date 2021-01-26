using System;
using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class Scale
    {
        public long Id { get; set; }
        public DateTime Day { get; set; }
        public bool Active { get; set; }
    }
}
