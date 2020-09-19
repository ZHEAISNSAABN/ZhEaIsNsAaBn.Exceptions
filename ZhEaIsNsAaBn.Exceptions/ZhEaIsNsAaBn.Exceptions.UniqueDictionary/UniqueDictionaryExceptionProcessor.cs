using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    internal class UniqueDictionaryExceptionProcessor : IExceptionProcessor
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
                var MyException = (UniqueDictionaryException)exception;
                if (MyException.ExceptionType == UniqueDictionaryExceptionType.KeyAndValueCanNotBeNull)
                {
                    exceptionData = exceptionDataSetter.CreatExceptionData(
                        UniqueDictionaryExceptionType.KeyAndValueCanNotBeNull,
                        Severity.High,
                        Retry.CanRetry.No,
                        Retry.DefultTryNum.No,
                        exception,
                        caller);
                    return true;
                }
                else
                {

                    exceptionData = exceptionDataSetter.CreatExceptionData(
                        UniqueDictionaryExceptionType.UnHandle,
                        Severity.Medium,
                        Retry.CanRetry.Yes,
                        Retry.DefultTryNum.Unknown,
                        exception,
                        caller);
                    return true;
                }
            }

            return false;
        }

        public Type DefaultType => typeof(UniqueDictionaryException);
    }
}
