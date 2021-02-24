using System;
using System.Text.RegularExpressions;

namespace escala_server.Auxiliary
{
    public class Validator
    {
        public bool EmailValidator(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            var result = rg.IsMatch(email);
            return result;
        }
    }
}