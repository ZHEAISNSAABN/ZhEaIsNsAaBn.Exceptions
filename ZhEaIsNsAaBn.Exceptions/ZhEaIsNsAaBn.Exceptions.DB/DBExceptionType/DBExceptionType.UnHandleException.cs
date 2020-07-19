using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    public partial class DBExceptionType
    {
        /// <summary>
        /// An uncategorized exception for which.
        /// </summary>
        public static class UnHandleException
        {
            /// <summary>
            /// An uncategorized exception for sql Exceptions.
            /// </summary>
            public static readonly DBExceptionType SqlException = (DBExceptionType)UnHandle[0];

            /// <summary>
            /// An uncategorized exception for Entity FrameWork Exceptions.
            /// </summary>
            public static readonly DBExceptionType EFException = (DBExceptionType)UnHandle[1];

            /// <summary>
            /// An uncategorized exception for DataBase but its unknown.
            /// </summary>
            public static readonly DBExceptionType DbException = (DBExceptionType)UnHandle[2];

        }
    }
}
