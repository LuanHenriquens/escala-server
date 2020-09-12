using System;
using System.ComponentModel.DataAnnotations;

namespace escala_server.Data.Models
{
    public class Scale
    {
        [Key]
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public bool Active { get; set; }
    }
}
