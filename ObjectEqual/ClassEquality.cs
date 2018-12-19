using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ObjectEqual
{
    public class ClassEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => p.GetType().IsClass;
            }
        }

        public bool IsEqual(object source, object target)
        {
            var type = source.GetType();

            foreach (var prop in type.GetProperties())
            {
                foreach (var equality in EqualityCollection.Equalities)
                {
                    if (equality.MatchCondition(source))
                    {
                        var result = equality.IsEqual(prop.GetValue(source), prop.GetValue(target));

                        if (!result)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
