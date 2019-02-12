using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEquality
{
    public class CycleReferenceException : Exception
    {
        public CycleReferenceException() : base("The object equality is not support cycle-reference.")
        {

        }
    }
}
