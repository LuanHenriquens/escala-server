using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class MemberGroup
    {
        public long Id { get; set; }
        public long MemberId { get; set; }
        public long GroupId { get; set; }
        public bool Adm { get; set; }
        public bool Active { get; set; }
    }
}
