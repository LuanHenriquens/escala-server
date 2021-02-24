using System;
using System.Globalization;

namespace escala_server.Middleware.Exceptions
{
    public class SqlDataError : Exception
    {
        public SqlDataError() : base()
        {
        }

        public SqlDataError(string message) : base(message)
        {
        }

        public SqlDataError(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}