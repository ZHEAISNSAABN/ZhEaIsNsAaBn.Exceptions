using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    using System.Data.Common;

    internal class DBExceptionProcessor : IExceptionProcessor
    {


        private readonly IList<DbExceptionDbServerBaseProcessor> _processors;
        protected readonly IExceptionDataSetter _exceptionDataSetter;

        public DBExceptionProcessor(IExceptionDataSetter exceptionDataSetter, params DbExceptionDbServerBaseProcessor[] processors)
        {
            _exceptionDataSetter = exceptionDataSetter;
            _processors = processors;
        }

        public bool ExtractExceptionData(
            Exception exception,
            IExceptionDataSetter exceptionDataSetter,
            out ExceptionData exceptionData,
            string caller = null)
        {
            exceptionData = null;
            bool ReturnResult = false;

            DbException dbException = (DbException)exception;
            foreach (var processor in _processors)
            {
                if (processor.IsItMyException(dbException))
                    if (processor.LookupException(exception, exceptionDataSetter, out exceptionData, caller, FindCode(dbException)))
                    {
                        ReturnResult = true;
                        break;
                    }
            }


            if (exception.GetType() == DefaultType)
            {
                exceptionData = exceptionDataSetter.CreatExceptionData(
                    DBExceptionType.SqlException.InvalidData,
                    Severity.Medium,
                    Retry.CanRetry.No,
                    Retry.DefultTryNum.No,
                    exception,
                    caller);
                ReturnResult = true;
            }

            return ReturnResult;
            ;
        }

        public Type DefaultType => typeof(DbException);

        private int FindCode(DbException ex)
        {
            var t = ex.GetType();
            var p = t.GetProperty("Code");
            if (p == null) p = t.GetProperty("Number");
            if (p == null) return 0;
            return (int)p.GetValue(ex, null);
        }
    }
}
