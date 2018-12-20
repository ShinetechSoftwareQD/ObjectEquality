using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ObjectEquality
{
    internal class GenericCollectionEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => p.GetType().IsGenericType;
            }
        }

        public bool IsEqual(object source, object target)
        {
            var type = source.GetType();
            var genericType = type.GetGenericArguments()[0];

            var genericCollectionType = typeof(IEnumerable<>).MakeGenericType(genericType);

            if (type.GetInterfaces().Any(p => p == genericCollectionType))
            {
                var countMethod = type.GetMethod("get_Count");

                var sourceCount = (int)countMethod.Invoke(source, null);
                var targetCount = (int)countMethod.Invoke(target, null);

                if (sourceCount != targetCount)
                {
                    return false;
                }

                var sourceCollection = (source as IEnumerable<object>).ToList();
                var targetCollection = (target as IEnumerable<object>).ToList();

                for (var i = 0; i < sourceCount; i++)
                {
                    var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(sourceCollection[i]));

                    var result = equality.IsEqual(sourceCollection[i], targetCollection[i]);

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
