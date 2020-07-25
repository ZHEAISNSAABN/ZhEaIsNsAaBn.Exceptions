using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public partial class Notify
    {
        private static readonly Notify _Priority = 1;

        /// <summary>
        /// Represent the prioprity of notify.
        /// </summary>
        public sealed class Priority
        {
            public static readonly Notify High = _Priority[0];
            public static readonly Notify Medium = _Priority[1];
            public static readonly Notify Low = _Priority[2];
            public static readonly Notify Unknown = _Priority[100];
        }
    }
}
