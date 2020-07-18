using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public partial class Severity : Base<Severity>
    {
        public static readonly Severity High = 1;
        public static readonly Severity Medium = 2;
        public static readonly Severity Low = 3;
        public static readonly Severity Unknown = 100;
    }
}
