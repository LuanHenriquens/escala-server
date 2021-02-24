namespace escala_server.Data.Models
{
    public class MemberGroup
    {
        public long MemberId { get; set; }
        public long GroupId { get; set; }
        public bool Adm { get; set; }
        public bool Active { get; set; }

        public Member Member { get; set; }
        public Group Group { get; set; }
    }
}
