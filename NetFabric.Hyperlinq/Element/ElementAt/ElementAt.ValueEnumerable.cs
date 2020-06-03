using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index-- == 0)
                        return Option.Some(enumerator.Current);
                }
            }

            return Option.None;
        }

        
        static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, Predicate<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current) && index-- == 0)
                        return Option.Some(enumerator.Current);
                }
            }
            return Option.None;
        }

        
        static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, PredicateAt<TSource> predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var sourceIndex = 0; enumerator.MoveNext(); sourceIndex++)
                    {
                        if (predicate(enumerator.Current, sourceIndex) && index-- == 0)
                            return Option.Some(enumerator.Current);
                    }
                }
            }
            return Option.None;
        }

        
        static Option<TResult> ElementAt<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index-- == 0)
                        return Option.Some(selector(enumerator.Current));
                }
            }

            return Option.None;
        }

        
        public static Option<TResult> ElementAt<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var sourceIndex = 0; enumerator.MoveNext(); sourceIndex++)
                    {
                        if (sourceIndex == index)
                            return Option.Some(selector(enumerator.Current, sourceIndex));
                    }
                }
            }
            return Option.None;
        }

        
        static Option<TResult> ElementAt<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, Predicate<TSource> predicate, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current) && index-- == 0)
                        return Option.Some(selector(enumerator.Current));
                }
            }
            return Option.None;
        }
    }
}
