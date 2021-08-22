using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectEquality
{
    internal class ArrayEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => p.GetType().IsArray && (p as Array).Rank == 1;
            }
        }

        public bool IsEqual(object source, object target)
        {
            Array s = source as Array;
            Array t = target as Array;

            if (s.Length != t.Length)
            {
                return false;
            }

            if (ObjectEqualityOptions.Current.ArrayEqualityMode == ArrayEqualityMode.Strict)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(s.GetValue(i)));

                    var result = equality.IsEqual(s.GetValue(i), t.GetValue(i));

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return CheckSameItems(s, t);
            }

            return true;
        }

        private bool CheckSameItems(Array source, Array target)
        {
            var matchedItems = new List<object>();

            for (var i = 0; i < source.Length; i++)
            {
                var matched = false;

                for (var j = 0; j < target.Length; j++)
                {
                    if (!matchedItems.Any(p => p.Equals(target.GetValue(j))))
                    {
                        var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(source.GetValue(i)));

                        var result = equality.IsEqual(source.GetValue(i), target.GetValue(j));

                        if (result)
                        {
                            matchedItems.Add(target.GetValue(j));
                            matched = true;
                            break;
                        }
                    }
                }

                if (!matched)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
