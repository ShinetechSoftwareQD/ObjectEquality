using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEquality
{
    public class ObjectEqualityOptions
    {
        public ArrayEqualityMode ArrayEqualityMode
        {
            get; set;
        }


        public CollectionEqualityMode CollectionEqualityMode
        {
            get; set;
        }


        public static ObjectEqualityOptions Default { get; } = new ObjectEqualityOptions
        {
            ArrayEqualityMode = ArrayEqualityMode.Strict,
            CollectionEqualityMode = CollectionEqualityMode.Strict
        };


        public static ObjectEqualityOptions Current
        {
            get; set;
        } = Default;


        public static List<IEquality> Equalities { get; } = EqualityCollection.Equalities;
    }
}
