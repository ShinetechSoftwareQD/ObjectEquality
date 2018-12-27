using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEquality
{
    public static class EqualityCollection
    {
        public static readonly List<IEquality> Equalities = new List<IEquality> {
            new StructEquality(),
            new ValueTypeEquality(),
            new ArrayEquality(),
            new TwoDimensionArrayEquality(),
            new GenericCollectionEquality(),
            new ClassEquality()
        };
    }
}
