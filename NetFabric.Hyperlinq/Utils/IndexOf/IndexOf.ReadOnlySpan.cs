using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf<TSource>(ReadOnlySpan<TSource> source, TSource item)
        {
            if (source.IsEmpty)
                return -1;

            if (Utils.IsValueType<TSource>())
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var arrayItem = source[index];
                    if (EqualityComparer<TSource>.Default.Equals(arrayItem, item))
                        return index;
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TSource>.Default;
                for (var index = 0; index < source.Length; index++)
                {
                    var arrayItem = source[index];
                    if (defaultComparer.Equals(arrayItem, item))
                        return index;
                }
            }

            return -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOf<TSource, TResult, TSelector>(ReadOnlySpan<TSource> source, TResult item, TSelector selector)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.IsEmpty)
                return -1;

            if (Utils.IsValueType<TSource>())
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var arrayItem = source[index];
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(arrayItem), item))
                        return index;
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TResult>.Default;
                for (var index = 0; index < source.Length; index++)
                {
                    var arrayItem = source[index];
                    if (defaultComparer.Equals(selector.Invoke(arrayItem), item))
                        return index;
                }
            }

            return -1;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int IndexOfAt<TSource, TResult, TSelector>(ReadOnlySpan<TSource> source, TResult item, TSelector selector)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.IsEmpty)
                return -1;

            if (Utils.IsValueType<TSource>())
            {
                for (var index = 0; index < source.Length; index++)
                {
                    var arrayItem = source[index];
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(arrayItem, index), item))
                        return index;
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TResult>.Default;
                for (var index = 0; index < source.Length; index++)
                {
                    var arrayItem = source[index];
                    if (defaultComparer.Equals(selector.Invoke(arrayItem, index), item))
                        return index;
                }
            }

            return -1;
        }

    }
}
