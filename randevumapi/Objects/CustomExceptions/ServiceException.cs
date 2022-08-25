using System;

namespace RandevumAPI.Objects.CustomExceptions
{
    [Serializable]
    public class ServiceException : Exception
    {
        public int Code { get; }

        public ServiceException() { }

        public ServiceException(string message)
            : base(message) { }

        public ServiceException(string message, Exception inner)
            : base(message, inner) { }

        public ServiceException(string message, int code)
        : this(message)
        {
            Code = code;
        }
    }
}