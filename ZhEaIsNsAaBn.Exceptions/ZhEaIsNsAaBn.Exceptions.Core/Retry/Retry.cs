using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public partial class Retry :Base<Retry>
    {
        #region Base<Retry> defult Initializer
        public Retry(ulong id) : base(id)
        {
        }

        public Retry() : base()
        {
        }

        protected override int Key => 10; //be sure it's diferent for each inherit class and biger than 8

        public static implicit operator Retry(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }
            return new Retry((ulong)id);
        }

        protected override Retry NewInstance(ulong id) => new Retry(id);


        #endregion
    }
}
