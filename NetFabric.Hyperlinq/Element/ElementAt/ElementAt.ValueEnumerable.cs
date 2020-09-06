using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
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

        
        static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, int index, TPredicate predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate.Invoke(enumerator.Current) && index-- == 0)
                        return Option.Some(enumerator.Current);
                }
            }
            return Option.None;
        }

        
        static Option<TSource> ElementAtAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, int index, TPredicate predicate) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var sourceIndex = 0; enumerator.MoveNext(); sourceIndex++)
                    {
                        if (predicate.Invoke(enumerator.Current, sourceIndex) && index-- == 0)
                            return Option.Some(enumerator.Current);
                    }
                }
            }
            return Option.None;
        }

        
        static Option<TResult?> ElementAt<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, NullableSelector<TSource, TResult> selector) 
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

        
        public static Option<TResult?> ElementAt<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, int index, NullableSelectorAt<TSource, TResult> selector) 
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

        
        static Option<TResult?> ElementAt<TEnumerable, TEnumerator, TSource, TResult, TPredicate>(this TEnumerable source, int index, TPredicate predicate, NullableSelector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IPredicate<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate.Invoke(enumerator.Current) && index-- == 0)
                        return Option.Some(selector(enumerator.Current));
                }
            }
            return Option.None;
        }
    }
}
