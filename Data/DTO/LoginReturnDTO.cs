using escala_server.Auxiliary.Security.Classes;

namespace escala_server.Data.DTO
{
    public class LoginReturnDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool Adm { get; set; }
        public Token Token { get; set; }
    }
}