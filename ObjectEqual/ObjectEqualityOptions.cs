using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEquality
{
    public class ObjectEqualityOptions
    {
        public ArrayEqualityMode ArrayEqualityMode
        {
            get; set;
        }

        public static ObjectEqualityOptions Default { get; } = new ObjectEqualityOptions
        {
            ArrayEqualityMode = ArrayEqualityMode.Strict
        };

        public static ObjectEqualityOptions Current
        {
            get; set;
        } = Default;
    }
}
