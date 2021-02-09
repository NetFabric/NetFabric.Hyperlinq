using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool Contains<TSource>(this ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource>? comparer = default)
        {
            if (source.Length is 0)
                return false;

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(ReadOnlySpan<TSource> source, TSource value)
            {
                foreach (var item in source)
                {
                    if (EqualityComparer<TSource>.Default.Equals(item, value))
                        return true;
                }
                return false;
            }

            static bool ComparerContains(ReadOnlySpan<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            {
                foreach (var item in source)
                {
                    if (comparer.Equals(item, value))
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
                foreach (var item in source)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(item), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;
                foreach (var item in source)
                {
                    if (defaultComparer.Equals(selector.Invoke(item), value))
                        return true;
                }
                return false;
            }
        }

        static bool ContainsRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, TResult>
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
                foreach (ref readonly var item in source)
                {
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in item), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;
                foreach (ref readonly var item in source)
                {
                    if (defaultComparer.Equals(selector.Invoke(in item), value))
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

        static bool ContainsAtRef<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
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
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(in source[index], index), value))
                        return true;
                }
                return false;
            }

            static bool ReferenceContains(ReadOnlySpan<TSource> source, TResult value, TSelector selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;
                for (var index = 0; index < source.Length; index++)
                {
                    if (defaultComparer.Equals(selector.Invoke(in source[index], index), value))
                        return true;
                }
                return false;
            }
        }
    }
}

