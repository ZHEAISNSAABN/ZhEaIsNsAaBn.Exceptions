using System;
using ZhEaIsNsAaBn.Exceptions.DependencyInjection;

namespace ZhEaIsNsAaBn.Exceptions.Test
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Unity;

    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
            var register = container.Resolve<AutoRegister>();
            register.Register(new List<Type>{typeof(DBExceptionRegister)});
            Console.WriteLine("Hello World!");

            try
            {
                throw new DbUpdateException("I dont Know", new Exception());
            }
            catch (Exception e)
            {
                var exceptionData = container.Resolve<IExceptionHandler>().Handle(e);

                Console.WriteLine(exceptionData.ToString());
            }
        }
    }
}
