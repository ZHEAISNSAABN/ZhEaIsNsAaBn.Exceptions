using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DependencyInjection
{
    using Unity;
    using Unity.Injection;

    using ZhEaIsNsAaBn.Exceptions;

    public static class RegisterTry
    {
        public static void AddTry(this IUnityContainer container)
        {
            container.RegisterSingleton<ITry, Try>();
        }

    }
}
