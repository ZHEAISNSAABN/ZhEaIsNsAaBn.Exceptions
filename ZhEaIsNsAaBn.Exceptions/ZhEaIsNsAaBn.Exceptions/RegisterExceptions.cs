using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    using Unity;

    using ZhEaIsNsAaBn.Exceptions.DependencyInjection;

    public static class RegisterExceptionsHandler
    {
        public static void AddExceptionsHandler(this IUnityContainer container)
        {
            container.RegisterSingleton<IExceptionDataSetter, ExceptionDataSetter>();
        }
        public static void AddMoreExceptionsHandler(this IUnityContainer container, List<Type> types)
        {
            List<ExceptionReceiverBase> receivers = null;
            if (types != null && types.Count > 0)
            {
                receivers = new List<ExceptionReceiverBase>();
                foreach (var item in types)
                {
                    receivers.Add(((RegisterBase)Activator.CreateInstance(item, container)).Register());
                }
            }

            container.RegisterInstance<IExceptionHandler>(new ExceptionHandler(
                container.Resolve<IExceptionDataSetter>(), receivers));

        }
    }
}
