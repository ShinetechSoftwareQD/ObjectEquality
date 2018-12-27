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
                return p =>
                {
                    var type = p.GetType();

                    if (type.IsGenericType)
                    {
                        var genericType = type.GetGenericArguments()[0];
                        var genericCollectionType = typeof(IEnumerable<>).MakeGenericType(genericType);

                        if (type.GetInterfaces().Any(x => x == genericCollectionType))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    return false;
                };
            }
        }

        public bool IsEqual(object source, object target)
        {
            var type = source.GetType();

            var countMethod = type.GetMethod("get_Count");

            var sourceCount = (int)countMethod.Invoke(source, null);
            var targetCount = (int)countMethod.Invoke(target, null);

            if (sourceCount != targetCount)
            {
                return false;
            }

            //var genericType = type.GetGenericArguments()[0];
            //var genericCollectionType = typeof(IEnumerable<>).MakeGenericType(genericType);

            var sourceCollection = source as IEnumerable<object>;
            var targetCollection = target as IEnumerable<object>;

            if (ObjectEqualityOptions.Current.CollectionEqualityMode == CollectionEqualityMode.Strict)
            {
                for (var i = 0; i < sourceCount; i++)
                {
                    var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(sourceCollection.ElementAt(i)));

                    var result = equality.IsEqual(sourceCollection.ElementAt(i), targetCollection.ElementAt(i));

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return CheckSameItems(sourceCollection, targetCollection);
            }

            return true;
        }

        private bool CheckSameItems(IEnumerable<object> source, IEnumerable<object> target)
        {
            var matchedItems = new List<object>();

            foreach (var sourceItem in source)
            {
                var matched = false;

                var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(sourceItem));

                foreach (var targetItem in target)
                {
                    if (!matchedItems.Any(p => p.Equals(targetItem)))
                    {
                        var result = equality.IsEqual(sourceItem, targetItem);

                        if (result)
                        {
                            matchedItems.Add(targetItem);
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
