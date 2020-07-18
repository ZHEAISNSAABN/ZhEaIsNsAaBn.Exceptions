using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    public partial class DBExceptionType
    {
        /// <summary>
        /// Is it Entity FrameWork Exceptions.
        /// </summary>
        public static readonly ExceptionType EF = 2;

        /// <summary>
        /// is it  sql Exceptions.
        /// </summary>
        public static readonly ExceptionType Sql = 1;


        /// <summary>
        /// An uncategorized exception.
        /// </summary>
        protected static readonly ExceptionType UnHandle = 100;

    }
}
