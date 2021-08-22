using System;

namespace ObjectEquality
{
    public interface IEquality
    {
        Func<object, bool> MatchCondition { get; }

        bool IsEqual(object source, object target);
    }
}
