﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = null)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (comparer is null && source is ICollection<TSource> collection)
                return collection.Contains(value);

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(TEnumerable source, [AllowNull] TSource value)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (comparer.Equals(enumerator.Current, value))
                        return true;
                }
                return false;
            }
        }


        internal static bool Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, [AllowNull] TResult value, Selector<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            return default(TResult) is object
                ? ValueContains(source, value, selector)
                : ReferenceContains(source, value, selector);

            static bool ValueContains(TEnumerable source, [AllowNull] TResult value, Selector<TSource, TResult> selector)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(TEnumerable source, [AllowNull] TResult value, Selector<TSource, TResult> selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (defaultComparer.Equals(selector(enumerator.Current), value))
                        return true;
                }
                return false;
            }
        }


        internal static bool Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, [AllowNull] TResult value, SelectorAt<TSource, TResult> selector)
            where TEnumerable : notnull, IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            return default(TResult) is object
                ? ValueContains(source, value, selector)
                : ReferenceContains(source, value, selector);

            static bool ValueContains(TEnumerable source, [AllowNull] TResult value, SelectorAt<TSource, TResult> selector)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current, index), value))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TEnumerable source, [AllowNull] TResult value, SelectorAt<TSource, TResult> selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (defaultComparer.Equals(selector(enumerator.Current, index), value))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}
