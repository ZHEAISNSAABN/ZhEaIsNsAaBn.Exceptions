using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public class UniqueDictionaryExceptionType : Base<UniqueDictionaryExceptionType>
    {

        #region Base<ExceptionType> defult Initializer
        public UniqueDictionaryExceptionType(ulong id) : base(id)
        {
        }

        public UniqueDictionaryExceptionType() : base()
        {
        }

        protected override int Key => 9; //be sure it's diferent for each inherit class and biger than 8


        public static implicit operator UniqueDictionaryExceptionType(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }
            return new UniqueDictionaryExceptionType((ulong)id);
        }

        protected override UniqueDictionaryExceptionType NewInstance(ulong id) => new UniqueDictionaryExceptionType(id);

        #endregion


        public static readonly UniqueDictionaryExceptionType KeyAndValueCanNotBeNull = 0;

        /// <summary>
        /// An uncategorized exception.
        /// </summary>
        public static readonly UniqueDictionaryExceptionType UnHandle = 100;
    }
}
