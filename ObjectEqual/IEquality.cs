using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEqual
{
    public interface IEquality
    {
        Func<object, bool> MatchCondition { get; }

        bool IsEqual(object source, object target);
    }
}
