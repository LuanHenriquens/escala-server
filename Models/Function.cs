using System.Collections.Generic;

namespace escala_server.Models
{
    public class Function
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public ICollection<MemberFunction> MemberFunction { get; set; }
    }
}
