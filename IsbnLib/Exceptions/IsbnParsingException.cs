using System;

namespace IsbnLib.Exceptions
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-localized-exception-messages
    /// </summary>
    [Serializable]
    public class IsbnParsingException : Exception
    {
        public IsbnParsingException()
        { }

        internal IsbnParsingException(string message) 
            : base(message) 
        { }

        public IsbnParsingException(string message, Exception inner)
            : base(message, inner)
        { }

        /// <summary>
        /// Define any additional properties and constructors
        /// </summary>
    }
}
