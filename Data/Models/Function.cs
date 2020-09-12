using System.ComponentModel.DataAnnotations;

namespace escala_server.Data.Models
{
    public class Function
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
