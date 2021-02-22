﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class EnumerableExtensions
    {
        internal static bool Contains<TEnumerable, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IEnumerable<TSource>
        {
            if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
            {
                // ReSharper disable once HeapView.PossibleBoxingAllocation
                if (source is ICollection<TSource> collection)
                    return collection.Contains(value);

                if (Utils.IsValueType<TSource>())
                    return DefaultContains(source, value);
            }

            return ComparerContains(source, value, comparer);

            static bool DefaultContains(TEnumerable source, TSource value)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer)
            {
                comparer ??= EqualityComparer<TSource>.Default;
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (comparer.Equals(enumerator.Current, value))
                        return true;
                }
                return false;
            }
        }

        internal static bool Contains<TEnumerable, TEnumerator, TSource, TEnumeratorGenerator>(this TEnumerable source, TEnumeratorGenerator getEnumerator, TSource value, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            where TEnumeratorGenerator : struct, IFunction<TEnumerable, TEnumerator>
        {
            // TODO:
            //if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
            //{
            //    if (source is ICollection<TSource> collection)
            //        return collection.Contains(value);

            //    if (Utils.IsValueType<TSource>())
            //        return DefaultContains(source, value, getEnumerator);
            //}

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer, getEnumerator);

            static bool DefaultContains(TEnumerable source, TSource value, TEnumeratorGenerator getEnumerator)
            {
                using var enumerator = getEnumerator.Invoke(source);
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TEnumerable source, TSource value, IEqualityComparer<TSource> comparer, TEnumeratorGenerator getEnumerator)
            {
                using var enumerator = getEnumerator.Invoke(source);
                while (enumerator.MoveNext())
                {
                    if (comparer.Equals(enumerator.Current, value))
                        return true;
                }
                return false;
            }
        }
    }
}
