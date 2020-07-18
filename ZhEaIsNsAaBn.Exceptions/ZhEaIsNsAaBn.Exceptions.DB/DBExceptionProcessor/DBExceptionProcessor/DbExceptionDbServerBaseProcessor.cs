using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    using System.Data.Common;

    internal abstract class DbExceptionDbServerBaseProcessor
    {
        public abstract bool LookupException(
            Exception exception,
            IExceptionDataSetter exceptionDataSetter,
            out ExceptionData exceptionData,
            string caller = null,
            int ExceptionCode = 0 );

        public abstract bool IsItMyException(DbException exception);
    }
}
