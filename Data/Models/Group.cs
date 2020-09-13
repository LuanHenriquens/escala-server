using System.ComponentModel.DataAnnotations;

namespace escala_server.Data.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
