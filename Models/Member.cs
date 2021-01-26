using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace escala_server.Models
{
    public class Member
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string SecretWord { get; set; }
        public Blob Image { get; set; }
        public bool Adm { get; set; }
        public bool Active { get; set; }
    }
}
