using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DependencyInjection
{
    using Unity;
    using Unity.Injection;

    using ZhEaIsNsAaBn.Exceptions;

    public class TryRegister
    {
        private readonly IUnityContainer container;

        public TryRegister(IUnityContainer container)
        {
            this.container = container;
        }

        public void Register()
        {
            container.RegisterSingleton<ITry, Try>();
        }

    }
}
