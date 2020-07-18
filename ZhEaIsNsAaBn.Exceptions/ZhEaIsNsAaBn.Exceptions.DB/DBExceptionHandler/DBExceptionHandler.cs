using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    using System.Data.Common;
    using System.Data.SqlTypes;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;


    internal partial class DBExceptionHandler : ExceptionReceiverBase
    {
        public DBExceptionHandler(IExceptionDataSetter exceptionDataSetter)
            : base(exceptionDataSetter)
        {
        }
    }
}
