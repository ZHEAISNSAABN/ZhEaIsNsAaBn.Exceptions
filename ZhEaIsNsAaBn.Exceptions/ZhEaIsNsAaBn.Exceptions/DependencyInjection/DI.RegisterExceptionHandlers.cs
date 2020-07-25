using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DependencyInjection
{
    using System.Linq;

    using Unity;
    using Unity.Injection;

    public class RegisterExceptionHandlers
    {
        private readonly IUnityContainer container;
        public RegisterExceptionHandlers(IUnityContainer container)
        {
            this.container = container;

            RegisterInstances();

            //var types = GetAllTypes();
            //Register(types);
        }

        private void RegisterInstances()
        {
            container.RegisterSingleton<IExceptionDataSetter, ExceptionDataSetter>();
        }

        //private List<Type> GetAllTypes()
        //{
        //    var tt = AppDomain.CurrentDomain.GetAssemblies().SelectMany(As => As.GetType()).ToList();
        //        //.SelectMany(x => x.GetTypes())
        //        //.Where(x => typeof(RegisterBase).IsAssignableFrom(x))
        //        //.Select(x => x).ToList();
        //    return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
        //        .Where(x => typeof(RegisterBase).IsAssignableFrom(x) && x.Namespace == typeof(RegisterBase).Namespace && !x.IsInterface && !x.IsAbstract)
        //        .Select(x => x).ToList();
        //}

        public void Register(List<Type> types)
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
