using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    using System.Runtime.CompilerServices;

    public interface IExceptionReceiver
    {
        bool Handle(Exception exception, IExceptionDataSetter exceptionDataSetter, out ExceptionData exceptionData, [CallerMemberName] string Caller = null);
    }
}
