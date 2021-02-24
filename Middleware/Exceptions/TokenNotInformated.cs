using System;
using System.Globalization;

namespace escala_server.Middleware.Exceptions
{
    public class TokenNotInformated : Exception
    {
        public TokenNotInformated() : base()
        {
        }

        public TokenNotInformated(string message) : base(message)
        {
        }

        public TokenNotInformated(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}