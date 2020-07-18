using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{

    using Microsoft.EntityFrameworkCore;

    internal class DbUpdateConcurrencyExceptionProcessor : IExceptionProcessor
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
                    DBExceptionType.EFException.ConcurrencyException,
                    Severity.Medium,
                    Retry.CanRetry.Yes,
                    Retry.DefultTryNum.Unknown,
                    exception,
                    caller,
                    new Tuple<string, object>(
                        "DbEntity",
                        ((DbUpdateConcurrencyException)exception).Entries));
                return true;
            }

            return false;
        }

        public Type DefaultType => typeof(DbUpdateConcurrencyException);
    }
}
