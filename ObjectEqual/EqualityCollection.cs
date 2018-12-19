using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEqual
{
    public static class EqualityCollection
    {
        public static readonly List<IEquality> Equalities = new List<IEquality> {
            new ValueTypeEquality(),
            new ArrayEquality(),
            new GenericCollectionEquality(),
            new ClassEquality()
        };
    }
}
