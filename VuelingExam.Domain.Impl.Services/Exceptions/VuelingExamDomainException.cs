using System;

namespace VuelingExam.Domain.Impl.Services.Exceptions
{
    [SerializableAttribute]
    public class VuelingExamDomainException : Exception
    {
        public VuelingExamDomainException()
        {
        }

        public VuelingExamDomainException(string message) : base(message)
        {
        }

        public VuelingExamDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
