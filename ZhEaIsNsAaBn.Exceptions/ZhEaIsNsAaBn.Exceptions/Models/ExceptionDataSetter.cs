using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    using System.Collections;
    using System.Linq;
    using System.Reflection;

    public interface IExceptionDataSetter
    {
        ExceptionData CreatExceptionData(
            IBase ExceptionType,
            Severity SeverityLevel,
            Retry CanRetry,
            int DefultTryNum,
            Exception DefaultException,
            string Caller,
            params Tuple<string, object>[] AdditionalParams);

        //int LineNumber = 0,
        //string Procedure = null,
        //IEnumerable EntityValidationErrors = null,
        //IEnumerable DbEntity = null);
    }

    internal class ExceptionDataSetter : IExceptionDataSetter
    {
        public ExceptionData CreatExceptionData(
                IBase ExceptionType,
                Severity SeverityLevel,
                Retry CanRetry,
                int DefultTryNum,
                Exception DefaultException,
                string Caller,
                params Tuple<string, object>[] AdditionalData)
        //int LineNumber = 0,
        //    string Procedure = null,
        //    IEnumerable EntityValidationErrors = null,
        //    IEnumerable DbEntity = null)

        {
            return new ExceptionData
                       {
                           Caller = Caller,
                           CanRetry = CanRetry,
                           DefaultException = DefaultException,
                           DefultTryNum = DefultTryNum,
                           ExceptionType = ExceptionType,
                           HelpLink = DefaultException.HelpLink,
                           InnerException = DefaultException.InnerException,
                           SeverityLevel = SeverityLevel,
                           StackTrace = DefaultException.StackTrace,
                           SystemMessage = DefaultException.Message,
                           TargetSite = DefaultException.TargetSite,
                           AdditionalData = AdditionalData.ToList()

                           //DbEntity = DbEntity,
                           //EntityValidationErrors = EntityValidationErrors,
                           //LineNumber = LineNumber,
                           //Procedure = Procedure,

            };

        }
    }
}
