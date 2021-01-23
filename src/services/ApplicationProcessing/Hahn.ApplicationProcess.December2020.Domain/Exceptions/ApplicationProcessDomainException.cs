using System;

namespace Hahn.ApplicationProcess.December2020.Domain.Exceptions
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
