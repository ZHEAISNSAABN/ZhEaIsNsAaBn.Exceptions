using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    //using System.Data.Entity.Validation;

    //internal class DbEntityValidationExceptionProcessor : IExceptionProcessor
    //{
    //    public bool ExtractExceptionData(
    //        Exception exception,
    //        IExceptionDataSetter exceptionDataSetter,
    //        out ExceptionData exceptionData,
    //        string caller = null)
    //    {
    //        exceptionData = null;
    //        if (exception.GetType() == DefaultType)
    //        {
    //            exceptionData = exceptionDataSetter.CreatExceptionData(
    //                DBExceptionType.EFException.ValidationException,
    //                Severity.Medium,
    //                Retry.CanRetry.No,
    //                Retry.DefultTryNum.No,
    //                exception,
    //                caller,
    //                new Tuple<string, object>(
    //                    "EntityValidationErrors",
    //                    ((DbEntityValidationException)exception).EntityValidationErrors));
    //            return true;
    //        }

    //        return false;
    //    }

    //    public Type DefaultType => typeof(DbEntityValidationException);
    //}
}
