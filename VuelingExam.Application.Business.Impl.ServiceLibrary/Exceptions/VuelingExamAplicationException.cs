using System;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary.Exceptions
{
    [SerializableAttribute]
    public class VuelingExamAplicationException : Exception
    {
        public VuelingExamAplicationException()
        {
        }

        public VuelingExamAplicationException(string message) : base(message)
        {
        }

        public VuelingExamAplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
