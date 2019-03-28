using System;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary.Exceptions
{
    [SerializableAttribute]
    public class VuelingExamApplicationException : Exception
    {
        public VuelingExamApplicationException()
        {
        }

        public VuelingExamApplicationException(string message) : base(message)
        {
        }

        public VuelingExamApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
