using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source) where TEnumerable : IEnumerable<TSource>
        {
            using(var enumerator = source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    throw new InvalidOperationException("Sequence contains no elements");

                var first = enumerator.Current;

                if(enumerator.MoveNext())
                throw new InvalidOperationException("Sequence contains more than one element");

                return first;
            }
        }

        public static TSource Single<TEnumerable, TSource>(this TEnumerable enumerable, Func<TSource, bool> predicate) where TEnumerable : IEnumerable<TSource>
        {
            using(var enumerator = enumerable.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if(predicate(current))
                    {
                        // found first, keep going until end or find second
                        while(enumerator.MoveNext())
                        {
                            if(predicate(enumerator.Current))
                                throw new InvalidOperationException("Sequence contains more than one element");
                        }
                        return current;
                    }
                }
                throw new InvalidOperationException("Sequence contains no elements");
            }
        }
    }
}
