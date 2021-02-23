using System.Security.Cryptography;
using System.Text;

namespace escala_server.Auxiliary
{
    public class Security
    {
        public string EncryptPassword(string password)
        {
            HashAlgorithm md = SHA512.Create();
            var signInputBytes = Encoding.UTF8.GetBytes(password);
            var hash = md.ComputeHash(signInputBytes);
            var hexString = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
                if ((0xff & hash[i]) < 0x10) hexString.Append("0" + hash[i].ToString("x2"));
                else hexString.Append(hash[i].ToString("x2"));
            password = hexString.ToString();

            return password;
        }
    }
}