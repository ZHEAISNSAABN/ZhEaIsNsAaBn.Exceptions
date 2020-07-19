using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.DB
{
    public partial class DBExceptionType : Base<DBExceptionType>
    {
        #region Base<ExceptionType> defult Initializer
        public DBExceptionType(ulong id) : base(id)
        {
        }

        public DBExceptionType() : base()
        {
        }

        protected override int Key => 8; //be sure it's diferent for each inherit class and biger than 8


        public static implicit operator DBExceptionType(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }
            return new DBExceptionType((ulong)id);
        }

        protected override DBExceptionType NewInstance(ulong id) => new DBExceptionType(id);

        #endregion



        /// <summary>
        /// Is it Entity FrameWork Exceptions.
        /// </summary>
        public static readonly DBExceptionType EF = 2;

        /// <summary>
        /// is it  sql Exceptions.
        /// </summary>
        public static readonly DBExceptionType Sql = 1;


        /// <summary>
        /// An uncategorized exception.
        /// </summary>
        protected static readonly DBExceptionType UnHandle = 100;

    }
}
