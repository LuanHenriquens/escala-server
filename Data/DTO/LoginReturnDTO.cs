using escala_server.Auxiliary.Security.Classes;

namespace escala_server.Data.DTO
{
    public class LoginReturnDTO
    {
        public string Image { get; set; }
        public bool Adm { get; set; }
        public HomePageDTO Home { get; set; }
        public Token Token { get; set; }
    }
}