using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        public static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index-- is 0)
                        return Option.Some(enumerator.Current);
                }
            }

            return Option.None;
        }

        

        internal static Option<TSource> ElementAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, int index, TPredicate predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate.Invoke(enumerator.Current) && index-- is 0)
                        return Option.Some(enumerator.Current);
                }
            }
            return Option.None;
        }

        

        internal static Option<TSource> ElementAtAt<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, int index, TPredicate predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var sourceIndex = 0; enumerator.MoveNext(); sourceIndex++)
                    {
                        if (predicate.Invoke(enumerator.Current, sourceIndex) && index-- is 0)
                            return Option.Some(enumerator.Current);
                    }
                }
            }
            return Option.None;
        }

        

        internal static Option<TResult> ElementAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, int index, TSelector selector) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index-- is 0)
                        return Option.Some(selector.Invoke(enumerator.Current));
                }
            }

            return Option.None;
        }

        

        internal static Option<TResult> ElementAtAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, int index, TSelector selector) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var sourceIndex = 0; enumerator.MoveNext(); sourceIndex++)
                    {
                        if (sourceIndex == index)
                            return Option.Some(selector.Invoke(enumerator.Current, sourceIndex));
                    }
                }
            }
            return Option.None;
        }

        

        internal static Option<TResult> ElementAt<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, int index, TPredicate predicate, TSelector selector) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (index >= 0)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (predicate.Invoke(enumerator.Current) && index-- is 0)
                        return Option.Some(selector.Invoke(enumerator.Current));
                }
            }
            return Option.None;
        }
    }
}
