using System.ComponentModel.DataAnnotations;

namespace escala_server.Data.Models
{
    public class MemberFunction
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int FunctionId { get; set; }

        public bool Active { get; set; }
    }
}
