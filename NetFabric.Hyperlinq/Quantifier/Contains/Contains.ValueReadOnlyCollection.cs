using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer = null)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (comparer is null)
                {
                    while (enumerator.MoveNext())
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                            return true;
                    }
                }
                else
                {
                    while (enumerator.MoveNext())
                    {
                        if (comparer.Equals(enumerator.Current, value))
                            return true;
                    }
                }
            }
            return false;
        }

        [Pure]
        static bool Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (comparer is null)
                {
                    while (enumerator.MoveNext())
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current), value))
                            return true;
                    }
                }
                else
                {
                    while (enumerator.MoveNext())
                    {
                        if (comparer.Equals(selector(enumerator.Current), value))
                            return true;
                    }
                }
            }
            return false;
        }

        [Pure]
        static bool Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, SelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (comparer is null)
                {
                    checked
                    {
                        for (var index = 0; enumerator.MoveNext(); index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current, index), value))
                                return true;
                        }
                    }
                }
                else
                {
                    checked
                    {
                        for (var index = 0; enumerator.MoveNext(); index++)
                        {
                            if (comparer.Equals(selector(enumerator.Current, index), value))
                                return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
