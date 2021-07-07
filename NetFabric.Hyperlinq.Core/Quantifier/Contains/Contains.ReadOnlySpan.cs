using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
        {
            return source switch
            {
                { Length: 0 } => false,
                _ => comparer.UseDefaultComparer()
                    ? ValueContains(source, value)
                    : ReferenceContains(source, value, comparer)
            };

            static bool ValueContains(ReadOnlySpan<TSource> source, TSource value)
            {
                foreach (var item in source)
                {
                    if (EqualityComparer<TSource>.Default.Equals(item, value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            {
                comparer ??= EqualityComparer<TSource>.Default;
                foreach (var item in source)
                {
                    if (comparer.Equals(item, value))
                        return true;
                }
                return false;
            }
        }


        static bool Contains<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source switch
            {
                { Length: 0 } => false,
                _ => comparer.UseDefaultComparer()
                    ? ValueContains(source, value, selector)
                    : ReferenceContains(source, value, comparer, selector)
            };

            static bool ValueContains(ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            {
                foreach (var item in source)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(ReadOnlySpan<TSource> source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector)
            {
                comparer ??= EqualityComparer<TResult>.Default;
                foreach (var item in source)
                {
                    if (comparer.Equals(selector.Invoke(item), value))
                        return true;
                }
                return false;
            }
        }


        static bool ContainsAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source switch
            {
                { Length: 0 } => false,
                _ => Utils.IsValueType<TResult>()
                    ? ValueContains(source, value, selector)
                    : ReferenceContains(source, value, comparer, selector),
            };

            static bool ValueContains(ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(source[index], index), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(ReadOnlySpan<TSource> source, TResult value, IEqualityComparer<TResult>? comparer, TSelector selector)
            {
                comparer ??= EqualityComparer<TResult>.Default;
                for (var index = 0; index < source.Length; index++)
                {
                    if (comparer.Equals(selector.Invoke(source[index], index), value))
                        return true;
                }
                return false;
            }
        }
    }
}

