using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class Member
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SecretWord { get; set; }
        public string Image { get; set; }
        public bool Adm { get; set; }
        public bool Active { get; set; }
    }
}
