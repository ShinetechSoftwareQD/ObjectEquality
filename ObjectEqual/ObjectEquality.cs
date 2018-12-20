using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ObjectEquality
{
    public class ObjectEquality
    {
        public ObjectEquality()
        {

        }

        public ObjectEquality(ObjectEqualityOption option)
        {
            ObjectEqualityOption.Current = option;
        }

        public bool IsEqual(object source, object target)
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
