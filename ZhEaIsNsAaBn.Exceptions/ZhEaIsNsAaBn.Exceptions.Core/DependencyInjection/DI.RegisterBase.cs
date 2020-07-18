using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DependencyInjection
{
    using Unity;

    public abstract class RegisterBase
    {
        protected readonly IUnityContainer container;

        public RegisterBase(IUnityContainer container)
        {
            this.container = container;
        }

        public abstract ExceptionReceiverBase Register();
    }
}
