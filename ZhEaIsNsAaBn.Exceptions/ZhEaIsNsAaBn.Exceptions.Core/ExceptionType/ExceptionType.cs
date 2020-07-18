using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public partial class ExceptionType : Base<ExceptionType>
    {
        #region Base<ExceptionType> defult Initializer
        public ExceptionType(ulong id) : base(id)
        {
        }

        public ExceptionType() : base()
        {
        }

        protected override int Key => 8; //be sure it's diferent for each inherit class and biger than 8


        public static implicit operator ExceptionType(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }
            return new ExceptionType((ulong)id);
        }

        protected override ExceptionType NewInstance(ulong id) => new ExceptionType(id);


        #endregion


        /// <summary>
        /// An uncategorized exception.
        /// </summary>
        public static readonly ExceptionType UnHandle = 100;

    }
}
