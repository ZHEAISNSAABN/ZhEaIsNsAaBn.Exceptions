using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    using System.Runtime.CompilerServices;

    public interface IExceptionHandler
    {
        ExceptionData Handle(Exception exception, [CallerMemberName] string Caller = null);

        void SetNext(ExceptionReceiverBase next);
    }

    public class ExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionDataSetter exceptionDataSetter;

        private readonly IList<ExceptionReceiverBase> receivers;

        public ExceptionHandler(IExceptionDataSetter exceptionDataSetter, params ExceptionReceiverBase[] receivers)
        {
            this.exceptionDataSetter = exceptionDataSetter;
            this.receivers = receivers;
        }

        public ExceptionData Handle(Exception exception, [CallerMemberName] string Caller = null)
        {
            ExceptionData ReturnExceptionData = DefaultExceptionData(exception, Caller);
            foreach (var receiver in receivers)
            {
                if(receiver.Handle(exception, exceptionDataSetter, out ReturnExceptionData, Caller))
                    break;
            }

            return ReturnExceptionData;
        }

        private ExceptionData DefaultExceptionData(Exception exception, [CallerMemberName] string Caller = null)
        {
            return new ExceptionData
                       {
                           ExceptionType = ExceptionType.UnHandle,
                           SeverityLevel = Severity.Unknown,
                           CanRetry = Retry.CanRetry.Yes,
                           DefultTryNum = Retry.DefultTryNum.Unknown,
                           SystemMessage = exception.Message,
                           InnerException = exception.InnerException,
                           DefaultException = exception,
                           HelpLink = exception.HelpLink,
                           StackTrace = exception.StackTrace,
                           TargetSite = exception.TargetSite,
                           Caller = Caller

                       };
        }

        public void SetNext(ExceptionReceiverBase next)
        {
            receivers.Add(next);
        }
    }
}
