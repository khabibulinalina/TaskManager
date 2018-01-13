using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.Helpers
{
    public class OperationResult<T, R>
    {
        public T Data { get; set; }
        public R Result { get; set; }
    }
}
