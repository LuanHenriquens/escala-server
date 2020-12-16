using escala_server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace escala_server.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Function> Function { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<MemberFunction> MemberFunction { get; set; }
        public DbSet<MemberGroup> MemberGroup { get; set; }
        public DbSet<MemberScale> MemberScale { get; set; }
        public DbSet<Scale> Scale { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<SongScale> SongScale { get; set; }
    }
}