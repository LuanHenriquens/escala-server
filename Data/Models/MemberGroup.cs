using System.ComponentModel.DataAnnotations;

namespace escala_server.Data.Models
{
    public class MemberGroup
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int GroupId { get; set; }

        public bool Admin { get; set; }

        public bool Active { get; set; }
    }
}
