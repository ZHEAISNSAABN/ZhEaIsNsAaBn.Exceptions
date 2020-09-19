using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    internal partial class UniqueDictionaryExceptionHandler : ExceptionReceiverBase
    {
        public UniqueDictionaryExceptionHandler(IExceptionDataSetter exceptionDataSetter)
            : base(exceptionDataSetter)
        {
        }
    }
}
