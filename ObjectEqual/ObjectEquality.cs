using System.Collections.Generic;
using System.Linq;

namespace ObjectEquality
{
    public class ObjectEquality
    {
        internal static List<object> ReferenceObjects = new List<object>();

        public ObjectEquality()
        {

        }

        public ObjectEquality(ObjectEqualityOptions option)
        {
            ObjectEqualityOptions.Current = option;
        }

        private void ResetReferenceObjects()
        {
            ReferenceObjects = new List<object>();
        }

        public bool IsEqual(object source, object target)
        {
            ResetReferenceObjects();

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

        public bool IsEqual<T>(T source, T target)
        {
            ResetReferenceObjects();

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
