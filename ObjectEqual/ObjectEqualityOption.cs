using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEquality
{
    public class ObjectEqualityOption
    {
        public ArrayEqualityMode ArrayEqualityMode
        {
            get; set;
        }

        public static ObjectEqualityOption Default { get; } = new ObjectEqualityOption
        {
            ArrayEqualityMode = ArrayEqualityMode.Strict
        };

        public static ObjectEqualityOption Current
        {
            get; set;
        } = Default;
    }
}
