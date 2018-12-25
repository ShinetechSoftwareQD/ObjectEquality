using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ObjectEquality
{
    public static class ObjectExtension
    {
        public static bool IsEqual(this object source, object target)
        {
            if (source.GetType() != target.GetType())
            {
                return false;
            }

            if (source == null && target == null)
            {
                return true;
            }
            else if (source == null && target != null)
            {
                return false;
            }
            else if (source != null && target == null)
            {
                return false;
            }

            var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(source));

            return equality.IsEqual(source, target);
        }
    }
}
