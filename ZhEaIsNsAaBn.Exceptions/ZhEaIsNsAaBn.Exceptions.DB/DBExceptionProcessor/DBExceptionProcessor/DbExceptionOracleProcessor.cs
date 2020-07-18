using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    using System.Data.Common;

    class DbExceptionOracleProcessor : DbExceptionDbServerBaseProcessor
    {
        public override bool LookupException(
            Exception exception,
            IExceptionDataSetter exceptionDataSetter,
            out ExceptionData exceptionData,
            string caller = null,
            int ExceptionCode = 0)
        {
            exceptionData = null;
            bool ReturnResult = false;
            DbException DbException = (DbException)exception;

            if (DbException != null)
            {
                if (ExceptionCode > 0)
                    switch (ExceptionCode)
                    {

                        case 1:
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.UniqueConstraint,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 54: //Resource busy and acquire with NOWAIT specified
                        case 60: //deadlock detected while waiting for resource
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.DeadlockVictim,
                                Severity.High,
                                Retry.CanRetry.Yes,
                                Retry.DefultTryNum.Unknown,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1400:
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.Null,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1403:
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.NoDataFound,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1422:
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.TooManyRows,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1438:
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.OutofRange,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1861: //Literal does not match format string (TO_DATE)
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.InvalidData,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 2291:
                        case 2292:
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.ForeignKey,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 12203: //TNS: unable to connect to destination
                        case 12224: //TNS: no listener
                        case 12505: //TNS:listener does not currently know of SID given in connect descriptor
                        case 12541: //TNS: no listener
                        case 12545: //Connect failed because target host or object does not exist
                        case 17002:
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.DatabaseNotAccessible,
                                Severity.High,
                                Retry.CanRetry.Yes,
                                Retry.DefultTryNum.Unknown,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1017: //invalid username/password; logon denied
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.UnknownUserOrPassword,
                                Severity.High,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 12899:
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.OutofRange,
                                Severity.High,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;



                    }
            }

            if (!ReturnResult)
            {
                exceptionData = exceptionDataSetter.CreatExceptionData(
                    DBExceptionType.UnHandleException.SqlException,
                    Severity.High,
                    Retry.CanRetry.No,
                    Retry.DefultTryNum.No,
                    exception,
                    caller);

                ReturnResult = true;
            }

            return ReturnResult;
        }


        public override bool IsItMyException(DbException exception)
        {
            ///"reflection works across"
            ///System.Data.OracleClient, Oracle.DataAccess.Client (ODP)
            ///also DDTek.Oracle, Devart.Data.Oracle
            ///TODO: reference provider directly.

            return exception.GetType().Name.Equals("OracleException", StringComparison.OrdinalIgnoreCase);
        }

    }
}
