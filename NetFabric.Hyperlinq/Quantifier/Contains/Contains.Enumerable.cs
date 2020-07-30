using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class EnumerableExtensions
    {
        internal static bool Contains<TEnumerable, TSource>(this TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : notnull, IEnumerable<TSource>
        {
            if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
            {
                if (source is ICollection<TSource> collection)
                    return collection.Contains(value!);

                if (Utils.IsValueType<TSource>())
                    return DefaultContains(source, value);
            }

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(TEnumerable source, [AllowNull] TSource value)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value!))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (comparer.Equals(enumerator.Current, value!))
                        return true;
                }
                return false;
            }
        }

        internal static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : notnull, IEnumerable<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            // TODO:
            //if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
            //{
            //    if (source is ICollection<TSource> collection)
            //        return collection.Contains(value!);

            //    if (Utils.IsValueType<TSource>())
            //        return DefaultContains(source, value, getEnumerator);
            //}

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer, getEnumerator);

            static bool DefaultContains(TEnumerable source, [AllowNull] TSource value, Func<TEnumerable, TEnumerator> getEnumerator)
            {
                using var enumerator = getEnumerator(source);
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value!))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer, Func<TEnumerable, TEnumerator> getEnumerator)
            {
                using var enumerator = getEnumerator(source);
                while (enumerator.MoveNext())
                {
                    if (comparer.Equals(enumerator.Current, value!))
                        return true;
                }
                return false;
            }
        }
    }
}
