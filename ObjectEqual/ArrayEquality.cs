using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ObjectEquality
{
    internal class ArrayEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => p.GetType().IsArray;
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

            for (var i = 0; i < s.Length; i++)
            {
                if (ObjectEqualityOption.Current.ArrayEqualityMode == ArrayEqualityMode.Strict)
                {
                    var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(s.GetValue(i)));

                    var result = equality.IsEqual(s.GetValue(i), t.GetValue(i));

                    if (!result)
                    {
                        return false;
                    }
                }
                else
                {

                }
            }

            return true;
        }
    }
}
