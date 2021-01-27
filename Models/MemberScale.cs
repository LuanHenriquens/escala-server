namespace escala_server.Models
{
    public class MemberScale
    {
        public long ScaleId { get; set; }
        public long MemberId { get; set; }
        public bool Active { get; set; }

        public Member Member { get; set; }
        public Scale Scale { get; set; }
    }
}
