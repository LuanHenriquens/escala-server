using System;
using System.Collections.Generic;

namespace escala_server.Models
{
    public class Scale
    {
        public long Id { get; set; }
        public DateTime Day { get; set; }
        public bool Active { get; set; }

        public ICollection<MemberScale> MemberScale { get; set; }
        public ICollection<SongScale> SongScale { get; set; }
    }
}
