using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    using System.Data.Common;

    internal class DbExceptionMSSQLProcessor : DbExceptionDbServerBaseProcessor
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
            SqlException sqlException = (SqlException)exception;

            if (sqlException != null)
                switch (sqlException.Number)
                {
                    case -1: //The server was not found or was not accessible.
                    case 2: //The server was not found or was not accessible.
                    case 1225: //The same of the upper ^
                    case 4060: //cannot open database requested by the login
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.DatabaseNotAccessible,
                            Severity.High,
                            Retry.CanRetry.Yes,
                            Retry.DefultTryNum.Unknown,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;

                    case -2: //The server Request Timeout.
                    case 8645: //A time out occurred while waiting for memory resources to execute the query,
                    case 30053: /* Word breaking timed out for the full-text query string.
                             * This can happen if the wordbreaker took a long time to process the full-text query string,
                             * or if a large number of queries are running on the server.
                             */
                    case 1222
                        : //Another transaction held a lock on a required resource longer than this query could wait for it.
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.RequestTimeout,
                            Severity.Medium,
                            Retry.CanRetry.Yes,
                            Retry.DefultTryNum.Max,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;




                    case 18456: //login failed for user
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.UnknownUserOrPassword,
                            Severity.High,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;



                    case 241: //Conversion failed when converting date and/or time from character string.
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.InvalidData,
                            Severity.High,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;



                    case 512: //Subquery returned more than 1 value. This is not permitted
                    case 511: //The operation you have tried has exceeded the maximum size of a row.
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.TooManyRows,
                            Severity.Medium,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;



                    case 515
                        : // Cannot insert the value NULL into column '%.*ls', table '%.*ls'; column does not allow nulls. %ls fails.
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.Null,
                            Severity.Medium,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;




                    case 1205
                        : //Resources are accessed in conflicting order on separate transactions, causing a deadlock
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.DeadlockVictim,
                            Severity.Medium,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;





                    case 2627
                        : //the error is typically raised because primary keys have not been managed appropriately across the topology.
                    case 2601: //The same of the upper ^
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.UniqueConstraint,
                            Severity.Medium,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;






                    case 547:
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.ForeignKey,
                            Severity.Medium,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;






                    case 8152: //String or binary data would be truncated.
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.StringTooLong,
                            Severity.Medium,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;






                    case 8115: //Arithmetic overflow error converting %ls to data type %ls.
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.InvalidType,
                            Severity.Medium,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;







                    case 50000: //all RAISERRORs with severity 10-20 will come here
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.CustomException,
                            Severity.Medium,
                            Retry.CanRetry.No,
                            Retry.DefultTryNum.No,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;








                    case 701: //There is insufficient system memory to run this query.
                    case 8651: //Other processes are consuming server memory (exerting memory pressure in the server).
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.OutOfMemory,
                            Severity.Medium,
                            Retry.CanRetry.Yes,
                            Retry.DefultTryNum.Unknown,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;








                    case 1204: //SQL Server cannot obtain a lock resource.
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.SqlException.OutOfLocks,
                            Severity.Medium,
                            Retry.CanRetry.Yes,
                            Retry.DefultTryNum.Unknown,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;








                    default:
                        exceptionData = exceptionDataSetter.CreatExceptionData(
                            DBExceptionType.UnHandleException.SqlException,
                            Severity.Unknown,
                            Retry.CanRetry.Yes,
                            Retry.DefultTryNum.Unknown,
                            exception,
                            caller,
                            new[]
                                {
                                    new Tuple<string, object>("LineNumber", sqlException.LineNumber),
                                    new Tuple<string, object>("Procedure", sqlException.Procedure)
                                });
                        ReturnResult = true;
                        break;


                }

            return ReturnResult;
        }

        public override bool IsItMyException(DbException exception)
        {
            return exception.GetType() == typeof(SqlException);

        }
    }
}
