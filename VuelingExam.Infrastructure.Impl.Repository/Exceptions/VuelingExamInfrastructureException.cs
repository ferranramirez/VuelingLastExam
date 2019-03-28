using System;

namespace VuelingExam.Infrastructure.Impl.Repository.Exceptions
{
    [SerializableAttribute]
    public class VuelingExamInfrastructureException : Exception
    {
        public VuelingExamInfrastructureException()
        {
        }

        public VuelingExamInfrastructureException(string message) : base(message)
        {
        }

        public VuelingExamInfrastructureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
