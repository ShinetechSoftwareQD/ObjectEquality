using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ObjectEquality
{
    internal class StructEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => p.GetType().IsValueType && !p.GetType().IsPrimitive && !p.GetType().IsEnum;
            }
        }

        public bool IsEqual(object source, object target)
        {
            var type = source.GetType();

            foreach (var prop in type.GetProperties())
            {
                var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(prop.GetValue(source)));


                var result = equality.IsEqual(prop.GetValue(source), prop.GetValue(target));

                if (!result)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
