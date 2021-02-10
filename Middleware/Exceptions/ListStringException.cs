using System;
using System.Collections.Generic;
using System.Globalization;

namespace escala_server.Middleware.Exceptions
{
    public class ListStringException : Exception
    {
        internal ListStringException(string message) : base(message)
        {
            TaskExceptions = new List<Exception>();
        }
        
        internal ListStringException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
        
        public ListStringException()
        {
            TaskExceptions = new List<Exception>();
        }

        public List<Exception> TaskExceptions { get; private set; }
    }
}