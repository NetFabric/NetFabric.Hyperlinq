using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source) where TEnumerable : IEnumerable<TSource>
        {
            using(var enumerator = source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    return default;

                var first = enumerator.Current;

                if(enumerator.MoveNext())
                    ThrowNotSingleSequence();

                return first;
            }

            void ThrowNotSingleSequence() => throw new InvalidOperationException("Sequence contains more than one element");
        }

        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable enumerable, Func<TSource, bool> predicate) where TEnumerable : IEnumerable<TSource>
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
                                ThrowNotSingleSequence();
                        }
                        return current;
                    }
                }
                return default;
            }

            void ThrowNotSingleSequence() => throw new InvalidOperationException("Sequence contains more than one element");
        }    
    }
}
