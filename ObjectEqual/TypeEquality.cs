using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEqual
{
    public class TypeEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => true;
            }
        }

        public bool IsEqual(object source, object target)
        {
            return source.GetType() == target.GetType();
        }
    }
}
