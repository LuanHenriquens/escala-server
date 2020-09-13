using System.ComponentModel.DataAnnotations;

namespace escala_server.Data.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PassWord { get; set; }

        public string Image { get; set; }

        public bool Admin { get; set; }

        public bool Active { get; set; }
    }
}
