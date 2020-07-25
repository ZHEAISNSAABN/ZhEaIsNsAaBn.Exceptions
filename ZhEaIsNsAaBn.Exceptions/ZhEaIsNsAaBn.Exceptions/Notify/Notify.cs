using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public partial class Notify : Base<Notify>
    {
        #region Base<Notify> defult Initializer
        public Notify(ulong id) : base(id)
        {
        }

        public Notify() : base()
        {
        }

        protected override int Key => 11; //be sure it's diferent for each inherit class and biger than 8

        public static implicit operator Notify(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }
            return new Notify((ulong)id);
        }

        protected override Notify NewInstance(ulong id) => new Notify(id);


        #endregion

    }
}
