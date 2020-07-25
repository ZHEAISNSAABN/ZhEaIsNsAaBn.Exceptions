using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions.Models
{
    public class Return<T>
    {
        public T Result { get; set; }
        public List<ExceptionData> ExceptionData { get; set; }
        public bool Worked { get; set; }
        public int Retries { get; set; }
    }
}
