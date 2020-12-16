using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool Contains<TList, TSource>(this ReadOnlySpan<TSource> source, TSource value)
            where TSource : struct
        {
            for (var index = 0; index < source.Length; index++)
            {
                if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                    return true;
            }
            return false;
        }

        public static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
        {
            if (source.Length == 0)
                return false;

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(ReadOnlySpan<TSource> source, TSource value)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(source[index], value))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (comparer.Equals(source[index], value))
                        return true;
                }
                return false;
            }
        }


        static bool Contains<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            return source.Length switch
            {
                0 => false,
                _ => Utils.IsValueType<TResult>()
                    ? ValueContains(source, value, selector)
                    : ReferenceContains(source, value, selector)
            };

            static bool ValueContains(ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            {
                for (var index = 0; index < source.Length; index++)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(source[index]), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                for (var index = 0; index < source.Length; index++)
                {
                    if (defaultComparer.Equals(selector.Invoke(source[index]), value))
                        return true;
                }
                return false;
            }
        }


        static bool ContainsAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            return source.Length switch
            {
                0 => false,
                _ => Utils.IsValueType<TResult>()
                    ? ValueContains(source, value, selector)
                    : ReferenceContains(source, value, selector),
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

            static bool ReferenceContains(ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                for (var index = 0; index < source.Length; index++)
                {
                    if (defaultComparer.Equals(selector.Invoke(source[index], index), value))
                        return true;
                }
                return false;
            }
        }
    }
}

