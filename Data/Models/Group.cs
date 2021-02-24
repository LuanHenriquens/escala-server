using System.Collections.Generic;

namespace escala_server.Data.Models
{
    public class Group
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public ICollection<MemberGroup> MemberGroup { get; set; }
    }
}
