using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource>(TSource[] source, Span<TSource> destination)
        {
            Debug.Assert(destination.Length >= source.Length);

            source.CopyTo(destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Copy<TSource, TResult, TSelector>(TSource[] source, TResult[] destination, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                destination[index] = selector.Invoke(item);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyRef<TSource, TResult, TSelector>(TSource[] source, TResult[] destination, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                destination[index] = selector.Invoke(in item);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyAt<TSource, TResult, TSelector>(TSource[] source, TResult[] destination, TSelector selector = default)
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                destination[index] = selector.Invoke(item, index);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyAtRef<TSource, TResult, TSelector>(TSource[] source, TResult[] destination, TSelector selector = default)
            where TSelector : struct, IFunctionIn<TSource, int, TResult>
        {
            Debug.Assert(destination.Length >= source.Length);

            var array = source;
            for (var index = 0; index < array.Length; index++)
            {
                ref readonly var item = ref array[index];
                destination[index] = selector.Invoke(in item, index);
            }
        }
    }
}
