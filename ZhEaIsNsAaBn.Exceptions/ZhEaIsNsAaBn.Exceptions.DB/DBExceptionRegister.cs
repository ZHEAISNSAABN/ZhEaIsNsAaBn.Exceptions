using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DependencyInjection
{
    using Unity;
    using Unity.Injection;

    using ZhEaIsNsAaBn.Exceptions.DB;

    public class DBExceptionRegister : RegisterBase
    {
        public DBExceptionRegister(IUnityContainer container)
            : base(container)
        {
        }

        public override ExceptionReceiverBase Register()
        {
            RegisterProcessors();
            return RegisterDBExceptionHandler();
        }

        private void RegisterProcessors()
        {

            #region DBExceptionProcessor


            container.RegisterSingleton<DbExceptionDbServerBaseProcessor, DbExceptionMSSQLProcessor>(nameof(DbExceptionMSSQLProcessor));
            container.RegisterSingleton<DbExceptionDbServerBaseProcessor, DbExceptionMySQLProcessor>(nameof(DbExceptionMySQLProcessor));
            container.RegisterSingleton<DbExceptionDbServerBaseProcessor, DbExceptionOracleProcessor>(nameof(DbExceptionOracleProcessor));


            container.RegisterSingleton<IExceptionProcessor, DBExceptionProcessor>(
                    nameof(DBExceptionProcessor),
                    new InjectionConstructor(
                        container.Resolve<DbExceptionDbServerBaseProcessor>(name: nameof(DbExceptionMSSQLProcessor)),
                        container.Resolve<DbExceptionDbServerBaseProcessor>(name: nameof(DbExceptionMySQLProcessor)),
                        container.Resolve<DbExceptionDbServerBaseProcessor>(name: nameof(DbExceptionOracleProcessor))));

            #endregion

            //container.RegisterSingleton<IExceptionProcessor, DbEntityValidationExceptionProcessor>(nameof(DbEntityValidationExceptionProcessor));
            container.RegisterSingleton<IExceptionProcessor, DbUpdateConcurrencyExceptionProcessor>(nameof(DbUpdateConcurrencyExceptionProcessor));
            container.RegisterSingleton<IExceptionProcessor, DbUpdateExceptionProcessor>(nameof(DbUpdateExceptionProcessor));
            container.RegisterSingleton<IExceptionProcessor, SqlTypeExceptionProcessor>(nameof(SqlTypeExceptionProcessor));

        }

        private ExceptionReceiverBase RegisterDBExceptionHandler()
        {
            container.RegisterSingleton<ExceptionReceiverBase, DBExceptionHandler>(nameof(DBExceptionHandler));

            
            var DBException = container.Resolve<IExceptionProcessor>(nameof(DBExceptionProcessor));
            //var DbEntityValidationException = container.Resolve<IExceptionProcessor>(nameof(DbEntityValidationExceptionProcessor));
            var DbUpdateConcurrencyException = container.Resolve<IExceptionProcessor>(nameof(DbUpdateConcurrencyExceptionProcessor));
            var DbUpdateException = container.Resolve<IExceptionProcessor>(nameof(DbUpdateExceptionProcessor));
            var SqlTypeException = container.Resolve<IExceptionProcessor>(nameof(SqlTypeExceptionProcessor));

            var exceptionReceiverBase = container.Resolve<ExceptionReceiverBase>(nameof(DBExceptionHandler));

            exceptionReceiverBase.AddProcessor(DBException.DefaultType, DBException);
            //exceptionReceiverBase.AddProcessor(DbEntityValidationException.DefaultType, DbEntityValidationException);
            exceptionReceiverBase.AddProcessor(DbUpdateConcurrencyException.DefaultType, DbUpdateConcurrencyException);
            exceptionReceiverBase.AddProcessor(DbUpdateException.DefaultType, DbUpdateException);
            exceptionReceiverBase.AddProcessor(SqlTypeException.DefaultType, SqlTypeException);

            return exceptionReceiverBase;
        }
    }
}
