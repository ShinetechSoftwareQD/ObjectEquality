using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEquality
{
    public interface IEquality
    {
        Func<object, bool> MatchCondition { get; }

        bool IsEqual(object source, object target);
    }
}
