using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    using Unity;

    using ZhEaIsNsAaBn.Exceptions.DependencyInjection;

    public class UniqueDictionaryExceptionTypeRegister : RegisterBase
    {

        public UniqueDictionaryExceptionTypeRegister(IUnityContainer container)
            : base(container)
        {
        }

        public override ExceptionReceiverBase Register()
        {
            container.RegisterSingleton<IExceptionProcessor, UniqueDictionaryExceptionProcessor>(nameof(UniqueDictionaryExceptionProcessor));

            container.RegisterSingleton<ExceptionReceiverBase, UniqueDictionaryExceptionHandler>(nameof(UniqueDictionaryExceptionHandler));


            var uniqueDictionaryExceptionProcessor = container.Resolve<IExceptionProcessor>(nameof(UniqueDictionaryExceptionProcessor));

            var exceptionReceiverBase = container.Resolve<ExceptionReceiverBase>(nameof(UniqueDictionaryExceptionHandler));

            exceptionReceiverBase.AddProcessor(uniqueDictionaryExceptionProcessor.DefaultType, uniqueDictionaryExceptionProcessor);

            return exceptionReceiverBase;
        }

    }
}
