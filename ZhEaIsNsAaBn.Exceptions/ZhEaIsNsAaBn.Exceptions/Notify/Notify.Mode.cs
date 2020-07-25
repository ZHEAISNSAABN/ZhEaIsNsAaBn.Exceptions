using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public partial class Notify
    {
        private static readonly Notify _Mode = 2;

        /// <summary>
        /// Represent the prioprity of notify.
        /// </summary>
        public sealed class Mode
        {
            public static readonly Notify ALL = _Mode[0];
            public static readonly Notify Email = _Mode[1];
            public static readonly Notify Log = _Mode[2];
            public static readonly Notify Whatsapp = _Mode[3];
        }
    }
}
