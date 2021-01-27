namespace escala_server.Models
{
    public class MemberFunction
    {
        public long MemberId { get; set; }
        public long FunctionId { get; set; }
        public bool Active { get; set; }

        public Member Member { get; set; }
        public Function Function { get; set; }
    }
}
