using System;
using System.Collections.Generic;
using System.Text;

namespace BPDT_lab1.DES
{
    public class WeakKeyException : Exception
    {
        public WeakKeyException(string message)
            : base(message) { }
    }
}
