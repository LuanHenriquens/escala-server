using escala_server.Models;
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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Function>().Property(p => p.Description).HasMaxLength(30).IsRequired();
            mb.Entity<Function>().Property(p => p.Active).IsRequired();
            
            mb.Entity<Group>().Property(p => p.Name).HasMaxLength(50).IsRequired();

            mb.Entity<Member>().Property(p => p.Name).HasMaxLength(50).IsRequired();
            mb.Entity<Member>().Property(p => p.SecretWord).HasMaxLength(100).IsRequired();

            mb.Entity<Song>().Property(p => p.Name).HasMaxLength(50).IsRequired();
            mb.Entity<Song>().Property(p => p.Singer).HasMaxLength(50).IsRequired();
            mb.Entity<Song>().Property(p => p.Link).HasMaxLength(100);
            mb.Entity<Song>().Property(p => p.Solo).HasMaxLength(20);
            mb.Entity<Song>().Property(p => p.Tone).HasMaxLength(3);

            mb.Entity<MemberFunction>().Property(p => p.MemberId).IsRequired(); //TODO: Aprender a definir a foreign key
            mb.Entity<MemberFunction>().Property(p => p.FunctionId).IsRequired(); //TODO: Aprender a definir a foreign key

            mb.Entity<MemberGroup>().Property(p => p.MemberId).IsRequired(); //TODO: Aprender a definir a foreign key
            mb.Entity<MemberGroup>().Property(p => p.GroupId).IsRequired(); //TODO: Aprender a definir a foreign key

            mb.Entity<MemberScale>().Property(p => p.MemberId).IsRequired(); //TODO: Aprender a definir a foreign key
            mb.Entity<MemberScale>().Property(p => p.ScaleId).IsRequired(); //TODO: Aprender a definir a foreign key

            mb.Entity<SongScale>().Property(p => p.ScaleId).IsRequired(); //TODO: Aprender a definir a foreign key
            mb.Entity<SongScale>().Property(p => p.SongId).IsRequired(); //TODO: Aprender a definir a foreign key
        }
    }
}