using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ObjectEquality
{
    internal class ClassEquality : IEquality
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

            if (ObjectEquality.ReferenceObjects.Any(p => p == source || p == target))
            {
                throw new CycleReferenceException();
            }

            ObjectEquality.ReferenceObjects.Add(source);
            ObjectEquality.ReferenceObjects.Add(target);

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
