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
            container.Resolve<RegisterExceptionHandlers>().Register(new List<Type> { typeof(DBExceptionRegister) });

            container.Resolve<TryRegister>().Register();
            var Itry = container.Resolve<ITry>();
            
            Console.WriteLine("Hello World!");

            var execute = Itry.Execute(
                () =>
                    {

                        throw new DbUpdateException("I dont Know", new Exception());
                        return true;
                    });

            var exceptionDataList = execute.ExceptionData;

            Console.WriteLine(execute.Retries);
            Console.WriteLine(execute.Result);
            Console.WriteLine(execute.Worked);

            foreach (var exceptionData in exceptionDataList)
            {
                Console.WriteLine(exceptionData.ExceptionType);
                Console.WriteLine(exceptionData.SeverityLevel);
                Console.WriteLine(exceptionData.CanRetry);
                Console.WriteLine(exceptionData.DefultTryNum);
            }

        }
    }
}
