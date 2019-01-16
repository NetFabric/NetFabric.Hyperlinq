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
                    ThrowEmptySequence();

                return enumerator.Current;
            }

            void ThrowEmptySequence() => throw new InvalidOperationException("Sequence contains no elements");
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
                ThrowEmptySequence();
                return default;
            }

            void ThrowEmptySequence() => throw new InvalidOperationException("Sequence contains no elements");
        }
    }
}
