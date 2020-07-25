using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    using System.Linq;

    public abstract class ExceptionReceiverBase : IExceptionReceiver
    {


        protected readonly Dictionary<Type, IExceptionProcessor> _processors;
        protected readonly IExceptionDataSetter _exceptionDataSetter;
        public ExceptionReceiverBase(IExceptionDataSetter exceptionDataSetter)
        {
            _exceptionDataSetter = exceptionDataSetter;
            _processors = new Dictionary<Type, IExceptionProcessor>();
        }


        public void AddProcessor(Type type, IExceptionProcessor processor)
        {
            _processors.Add(type, processor);
        }

        public bool Handle(
            Exception exception,
            IExceptionDataSetter exceptionDataSetter,
            out ExceptionData exceptionData,
            string caller = null)
        {
            exceptionData = null;

            var process = _processors.LastOrDefault(P => P.Key == exception.GetType()).Value;
            if (process != null)
                return process.ExtractExceptionData(exception, exceptionDataSetter, out exceptionData);


                return DefaultExceptionProcessor(exception, exceptionDataSetter, out exceptionData);
        }

        protected virtual bool DefaultExceptionProcessor(
            Exception exception,
            IExceptionDataSetter exceptionDataSetter,
            out ExceptionData exceptionData,
            string caller = null)
        {
            exceptionData = null;
            return false;
        }

    }
}
