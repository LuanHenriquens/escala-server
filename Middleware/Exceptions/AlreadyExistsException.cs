using System;
using System.Globalization;

namespace escala_server.Middleware.Exceptions
{
    public class AlreadyExistsException: Exception
    {
        public AlreadyExistsException() : base()
        {
        }

        public AlreadyExistsException(string message) : base(message)
        {
        }

        public AlreadyExistsException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}