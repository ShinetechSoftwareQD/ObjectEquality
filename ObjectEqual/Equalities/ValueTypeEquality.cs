﻿using System;

namespace ObjectEquality
{
    internal class ValueTypeEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => p.GetType().IsValueType || p.GetType() == typeof(string);
            }
        }

        public bool IsEqual(object source, object target)
        {
            return source.Equals(target);
        }
    }
}
