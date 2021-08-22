using System;
using System.Linq;

namespace ObjectEquality
{
    public class TwoDimensionArrayEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => p.GetType().IsArray && (p as Array).Rank == 2;
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

            var firstLevelRankBound = s.GetUpperBound(0) + 1;
            var secondLevelRankBound = s.GetUpperBound(1) + 1;

            for (var i = 0; i < firstLevelRankBound; i++)
            {
                for (var j = 0; j < secondLevelRankBound; j++)
                {
                    var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(s.GetValue(new int[] { i, j })));

                    var result = equality.IsEqual(s.GetValue(new int[] { i, j }), t.GetValue(new int[] { i, j }));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
