using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public interface IExceptionProcessor
    {
        bool ExtractExceptionData(
            Exception exception,
            IExceptionDataSetter exceptionDataSetter,
            out ExceptionData exceptionData,
            string caller = null);

        Type DefaultType { get; }
    }
}
