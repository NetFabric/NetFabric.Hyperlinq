using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
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


        internal static bool Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector)
                : ReferenceContains(source, value, selector);

            static bool ValueContains(TEnumerable source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current)!, value!))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(TEnumerable source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (defaultComparer.Equals(selector(enumerator.Current)!, value!))
                        return true;
                }
                return false;
            }
        }


        internal static bool Contains<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector)
                : ReferenceContains(source, value, selector);

            static bool ValueContains(TEnumerable source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(enumerator.Current, index)!, value!))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TEnumerable source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (defaultComparer.Equals(selector(enumerator.Current, index)!, value!))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}
