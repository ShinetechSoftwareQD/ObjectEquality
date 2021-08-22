using System.Collections.Generic;

namespace ObjectEquality
{
    internal static class EqualityCollection
    {
        internal static readonly List<IEquality> Equalities = new List<IEquality> {
            new StructEquality(),
            new ValueTypeEquality(),
            new ArrayEquality(),
            new TwoDimensionArrayEquality(),
            new GenericCollectionEquality(),
            new ClassEquality()
        };
    }
}
