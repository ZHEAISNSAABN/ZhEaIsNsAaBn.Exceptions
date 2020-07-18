using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    public partial class DBExceptionType
    {

        /// <summary>
        /// is it  sql Exceptions type.
        /// </summary>
        public static class SqlException
        {

            /// <summary>
            /// Cannot access the database.
            /// </summary>
            public static readonly ExceptionType DatabaseNotAccessible = Sql[0];

            /// <summary>
            /// User Or Password is incorrect.
            /// </summary>
            public static readonly ExceptionType UnknownUserOrPassword = Sql[1];

            /// <summary>
            /// A custom (RAISERROR) error occurred.
            /// </summary>
            public static readonly ExceptionType CustomException = Sql[2];

            /// <summary>
            /// Resources are accessed in conflicting order on separate transactions, causing a deadlock
            /// </summary>
            public static readonly ExceptionType DeadlockVictim = Sql[3];

            /// <summary>
            /// Data is invalid (string or number overflow, or datatype conversion, or foreign key constraint)
            /// </summary>
            public static readonly ExceptionType InvalidData = Sql[4];

            /// <summary>
            /// String is too long for column.
            /// </summary>
            public static readonly ExceptionType StringTooLong = Sql[5];

            /// <summary>
            /// Number is invalid for column definition
            /// </summary>
            public static readonly ExceptionType InvalidType = Sql[6];

            /// <summary>
            /// Null value not allowed in non-null column.
            /// </summary>
            public static readonly ExceptionType Null = Sql[7];

            /// <summary>
            /// Duplicate value violates unique (or primary key) constraint
            /// </summary>
            public static readonly ExceptionType UniqueConstraint = Sql[8];

            /// <summary>
            /// Value violates foreign key constraint
            /// </summary>
            public static readonly ExceptionType ForeignKey = Sql[9];

            /// <summary>
            /// Too many rows were found in sub-query.
            /// </summary>
            public static readonly ExceptionType TooManyRows = Sql[10];

            /// <summary>
            /// No data was found in sub-query.
            /// </summary>
            public static readonly ExceptionType NoDataFound = Sql[11];

            /// <summary>
            /// The server Request Timeout. Just retry & it will be fine
            /// </summary>
            public static readonly ExceptionType RequestTimeout = Sql[12];

            /// <summary>
            /// the requested operation because the minimum query memory is not available.
            /// Decrease the configured value for the 'min memory per query.
            /// </summary>
            public static readonly ExceptionType LowMemoryCondition = Sql[13];

            /// <summary>
            /// No data was found in sub-query.
            /// </summary>
            public static readonly ExceptionType MaximumSizeOfRow = Sql[14];

            /// <summary>
            /// There is insufficient system memory to run this query.
            /// rerun the query again
            /// </summary>
            public static readonly ExceptionType OutOfMemory = Sql[15];

            /// <summary>
            /// The instance of the SQL Server Database Engine cannot obtain a LOCK resource at this time.
            /// Rerun your statement when there are fewer active users.
            /// Ask the database administrator to check the lock and memory configuration for this instance,
            /// or to check for long-running transactions.
            /// </summary>
            public static readonly ExceptionType OutOfLocks = Sql[16];

            /// <summary>
            /// Cannot create a row of size %d which is greater than the allowable maximum of %d.
            /// </summary>
            public static readonly ExceptionType OutofRange = Sql[17];

        }

    }
}
