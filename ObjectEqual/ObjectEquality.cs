using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ObjectEqual
{
    public class ObjectEquality
    {
        public bool IsEqual(object source, object target)
        {
            foreach (var equality in EqualityCollection.Equalities)
            {
                if (equality.MatchCondition(source))
                {
                    var result = equality.IsEqual(source, target);

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
