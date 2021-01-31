namespace escala_server.Data.DTOs
{
    public class MemberLoginDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool Adm { get; set; }
    }
}