using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource First<TEnumerable, TSource>(this TEnumerable source) where TEnumerable : IEnumerable<TSource>
        {
            using(var enumerator = source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    throw new InvalidOperationException("Sequence contains no elements");

                return enumerator.Current;
            }
        }

        public static TSource First<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) where TEnumerable : IEnumerable<TSource>
        {
            using(var enumerator = source.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if(predicate(current))
                        return current;
                }
                throw new InvalidOperationException("Sequence contains no elements");
            }
        }
    }
}
