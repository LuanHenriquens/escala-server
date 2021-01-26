using System.ComponentModel.DataAnnotations;

namespace escala_server.Models
{
    public class MemberScale
    {
        [Key]
        public long Id { get; set; }
        public long ScaleId { get; set; }
        public long MemberId { get; set; }
        public bool Active { get; set; }
    }
}
