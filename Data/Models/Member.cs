using System.Collections.Generic;

namespace escala_server.Data.Models
{
    public class Member
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string SecretWord { get; set; }
        public string Image { get; set; }
        public bool Adm { get; set; }
        public bool Active { get; set; }

        public ICollection<MemberFunction> MemberFunction { get; set; }
        public ICollection<MemberGroup> MemberGroup { get; set; }
        public ICollection<MemberScale> MemberScale { get; set; }
    }
}
