using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source) where TEnumerable : IEnumerable<TSource>
        {
            using(var enumerator = source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    return default;

                return enumerator.Current;
            }
        }

        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) where TEnumerable : IEnumerable<TSource>
        {
            using(var enumerator = source.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if(predicate(current))
                        return current;
                }
                return default;
            }
        }
    }
}
