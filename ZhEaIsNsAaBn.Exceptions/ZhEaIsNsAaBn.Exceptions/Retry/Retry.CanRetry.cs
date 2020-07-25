using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public partial class Retry
    {
        private static readonly Retry _CanRetry = 1;

        /// <summary>
        /// are its normal exception so the defult is retry or not.
        /// </summary>
        public sealed class CanRetry
        {
            public static readonly Retry Yes = _CanRetry[0];
            public static readonly Retry No = _CanRetry[1];
        }
    }
}
