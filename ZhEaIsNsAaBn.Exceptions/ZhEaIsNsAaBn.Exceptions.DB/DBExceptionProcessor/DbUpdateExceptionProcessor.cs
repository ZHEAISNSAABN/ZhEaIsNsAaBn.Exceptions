using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    using Microsoft.EntityFrameworkCore;

    internal class DbUpdateExceptionProcessor : IExceptionProcessor
    {
        public bool ExtractExceptionData(
            Exception exception,
            IExceptionDataSetter exceptionDataSetter,
            out ExceptionData exceptionData,
            string caller = null)
        {
            exceptionData = null;
            if (exception.GetType() == DefaultType)
            {
                exceptionData = exceptionDataSetter.CreatExceptionData(
                    DBExceptionType.SqlException.InvalidData,
                    Severity.Medium,
                    Retry.CanRetry.No,
                    Retry.DefultTryNum.No,
                    exception,
                    caller);
                return true;
            }

            return false;
        }

        public Type DefaultType => typeof(DbUpdateException);
    }
}
