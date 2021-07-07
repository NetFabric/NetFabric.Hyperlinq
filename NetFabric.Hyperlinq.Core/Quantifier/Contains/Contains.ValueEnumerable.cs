using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource>? comparer = default)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (comparer.UseDefaultComparer())
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



        internal static bool Contains<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return comparer.UseDefaultComparer()
                ? ValueContains(source, value, selector)
                : ReferenceContains(source, value, comparer, selector);

            static bool ValueContains(TEnumerable source, TResult value, TSelector selector)
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(enumerator.Current), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (comparer.Equals(selector.Invoke(enumerator.Current), value))
                        return true;
                }
                return false;
            }
        }


        internal static bool ContainsAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return Utils.IsValueType<TResult>()
                ? ValueContains(source, value, selector)
                : ReferenceContains(source, value, comparer, selector);

            static bool ValueContains(TEnumerable source, TResult value, TSelector selector)
            {
                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(enumerator.Current, index), value))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(TEnumerable source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector)
            {
                comparer ??= EqualityComparer<TResult>.Default;

                using var enumerator = source.GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (comparer.Equals(selector.Invoke(enumerator.Current, index), value))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}
