using System;

namespace ApplicationProcess.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class ApplicationProcessDomainException : Exception
    {
        public ApplicationProcessDomainException()
        { }

        public ApplicationProcessDomainException(string message)
            : base(message)
        { }

        public ApplicationProcessDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
