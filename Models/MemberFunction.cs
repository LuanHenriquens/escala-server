using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class MemberFunction
    {
        [Key]
        public long Id { get; set; }
        public long MemberId { get; set; }
        public long FunctionId { get; set; }
        public bool Active { get; set; }
    }
}
