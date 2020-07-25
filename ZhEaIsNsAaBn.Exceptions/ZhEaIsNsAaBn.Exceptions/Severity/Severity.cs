using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public partial class Severity
    {
        #region Base<Severity> defult Initializer
        public Severity(ulong id) : base(id)
        {
        }

        public Severity() : base()
        {
        }
        protected override int Key => 9;

        public static implicit operator Severity(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }

            return new Severity((ulong)id);
        }

        protected override Severity NewInstance(ulong id)
        {
            return new Severity(id);
        }
        #endregion

    }
}
