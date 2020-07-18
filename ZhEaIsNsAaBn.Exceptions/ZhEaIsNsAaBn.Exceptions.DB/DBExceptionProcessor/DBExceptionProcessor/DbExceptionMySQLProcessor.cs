using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    using System.Data.Common;

    class DbExceptionMySQLProcessor : DbExceptionDbServerBaseProcessor
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

            ////http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
            if (DbException != null)
            {
                if (ExceptionCode > 0)
                    switch (ExceptionCode)
                    {
                        case 1022: //Can't write; duplicate key in table
                        case 1062: //Duplicate entry for key
                        case 1169: //Can't write, because of unique constraint
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.UniqueConstraint,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1044: //Access denied for user
                        case 1045: //Access denied for user
                        case 1046: //No database selected 
                        case 1049: //Unknown database
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.DatabaseNotAccessible,
                                Severity.High,
                                Retry.CanRetry.Yes,
                                Retry.DefultTryNum.Unknown,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1048: //Column cannot be null
                        case 1364: //Field doesn't have a default value
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.Null,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1264: //Out of range value for column
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.OutofRange,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1406: //Data too long for column
                            //could be InvalidNumberException - it's not distinguished
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.InvalidData,
                                Severity.High,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1217: //Cannot delete or update a parent row: a foreign key constraint fails 
                        case 1451: //Cannot delete or update a parent row: a foreign key constraint fails
                        case 1452: //Cannot add or update a child row: a foreign key constraint fails
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.ForeignKey,
                                Severity.Medium,
                                Retry.CanRetry.No,
                                Retry.DefultTryNum.No,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;






                        case 1099: //Table was locked with a READ lock and can't be updated 
                        case 1205: //Lock wait timeout exceeded; try restarting transaction 
                        case 1213: //Deadlock found when trying to get lock; try restarting transaction 
                            exceptionData = exceptionDataSetter.CreatExceptionData(
                                DBExceptionType.SqlException.DeadlockVictim,
                                Severity.High,
                                Retry.CanRetry.Yes,
                                Retry.DefultTryNum.Unknown,
                                exception,
                                caller);

                            ReturnResult = true;
                            break;
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
            }

            return ReturnResult;
        }


        public override bool IsItMyException(DbException exception)
        {
            return exception.GetType().Name.Equals("MySqlException", StringComparison.OrdinalIgnoreCase);

        }
    }
}
