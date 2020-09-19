using System;

namespace ZhEaIsNsAaBn.Exceptions
{
    public class UniqueDictionaryException : Exception
    {
        public UniqueDictionaryExceptionType ExceptionType { get; set; }
        public UniqueDictionaryException(UniqueDictionaryExceptionType ExceptionType) : base(ExceptionType.ToString())
        {
            this.ExceptionType = ExceptionType;
        }

    }
}